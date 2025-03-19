using Halliday.AI.Common.Interfaces;
using Halliday.AI.Common.Models;
using Microsoft.ML;

namespace Halliday.AI.Common;

public abstract class BaseModel(string modelRelativePath)
{
    private readonly string _qualifiedModelPath = GetMlNetModelPath(modelRelativePath);
    private readonly MLContext _mlContext = new();
    private ITransformer? _model;

    /// <summary>
    /// Permutation feature importance (PFI) is a technique to determine the importance 
    /// of features in a trained machine learning model. PFI works by taking a labeled dataset, 
    /// choosing a feature, and permuting the values for that feature across all the examples, 
    /// so that each example now has a random value for the feature and the original values for all other features.
    /// The evaluation metric (e.g. R-squared) is then calculated for this modified dataset, 
    /// and the change in the evaluation metric from the original dataset is computed. 
    /// The larger the change in the evaluation metric, the more important the feature is to the model.
    /// 
    /// PFI typically takes a long time to compute, as the evaluation metric is calculated 
    /// many times to determine the importance of each feature. 
    /// 
    /// </summary>
    /// <param name="label">Label column being predicted.</param>
    /// <param name="trainingValues">The values to parse the training data.</param>
    /// <typeparam name="TInput">Input data for the model.</typeparam>
    /// <returns>A list of each feature and its importance.</returns>
    protected List<Tuple<string, double>> Evaluate<TInput>(string label, TrainingValues trainingValues) where TInput : IModelInput
    {
        if (_model is null)
            LoadModel();

        var qualifiedTrainingPath = GetTrainModelPath(trainingValues.RelativeTrainingFilePath);
        var dataView = _mlContext.Data.LoadFromTextFile<TInput>(
            path: qualifiedTrainingPath,
            separatorChar: trainingValues.Separator,
            hasHeader: trainingValues.HasHeader,
            allowQuoting: trainingValues.AllowQuoting);
        
        var preProcessedData = _model!.Transform(dataView);
        
        var importance = _mlContext.MulticlassClassification.PermutationFeatureImportance(
                model: _model, 
                data: preProcessedData, 
                labelColumnName: label);
        
        var metrics = importance
             .Select(kvp => new { kvp.Key, kvp.Value.MacroAccuracy })
             .OrderByDescending(myFeatures => Math.Abs(myFeatures.MacroAccuracy.Mean));

        return metrics
            .Select(feature => Math.Abs(feature.MacroAccuracy.Mean))
            .Select(pfiValue => new Tuple<string, double>(label, pfiValue))
            .ToList();
    }

    protected void Train()
    {
    }

    protected void LoadModel()
    {
        _model = _mlContext.Model.Load(_qualifiedModelPath, out _);
    }

    private static string GetMlNetModelPath(string relativePath)
    {
        if (!relativePath.EndsWith(".mlnet"))
            throw new ArgumentException("File must end with '.mlnet'");

        return FormatPath(relativePath);
    }

    private static string GetTrainModelPath(string relativePath)
    {
        if (!relativePath.EndsWith(".txt"))
            throw new ArgumentException("File must end with '.txt'");

        return FormatPath(relativePath);
    }

    /// <summary>
    /// Formats the given path to point to the correct directory
    /// inside of Halliday.AI
    /// </summary>
    /// <param name="path">Relative path of given file.</param>
    /// <returns>Fully qualified path formatted.</returns>
    private static string FormatPath(string path)
    {
        // Pulls Path out of bin directory
        var modifiedPath = $"../../../{path}";
        var fullPath = Path.GetFullPath(modifiedPath);
        
        // When running Web project the full path uses Web due to it being
        // the applications current entry point
        if (fullPath.Contains("Halliday.Web"))
            fullPath = fullPath.Replace("Halliday.Web", "Halliday.AI");

        return fullPath;
    }
}