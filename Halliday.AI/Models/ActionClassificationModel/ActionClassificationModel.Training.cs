using Halliday.AI.Common.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;

namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationModel
{
    /// <summary>
    /// Train a new model with the provided dataset.
    /// </summary>
    /// <param name="outputModelPath">File-path for saving the model.</param>
    /// <param name="inputDataFilePath">Path to the data file for training.</param>
    /// <param name="separatorChar">Separator character for delimited training file.</param>
    /// <param name="hasHeader">Boolean if the training file has a header.</param>
    /// <param name="allowQuoting">Boolean if the file is allowed to have quotes.</param>
    private static void Train(string outputModelPath, string inputDataFilePath, char separatorChar, bool hasHeader, bool allowQuoting)
    {
        var mlContext = new MLContext();

        var data = LoadIDataViewFromFile(mlContext, inputDataFilePath, separatorChar, hasHeader, allowQuoting);
        var model = RetrainModel(mlContext, data);
        SaveModel(mlContext, model, data, outputModelPath);
    }

    /// <summary>
    /// Load an IDataView from a file path.
    /// </summary>
    /// <param name="mlContext">The common context for all ML.NET operations.</param>
    /// <param name="inputDataFilePath">Path to the data file for training.</param>
    /// <param name="separatorChar">Separator character for delimited training file.</param>
    /// <param name="hasHeader">Boolean if the training file has a header.</param>
    /// <param name="allowQuoting">Boolean if the file is allowed to have quotes.</param>
    /// <returns>IDataView with loaded training data.</returns>
    private static IDataView LoadIDataViewFromFile(MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader, bool allowQuoting)
    {
        return mlContext.Data.LoadFromTextFile<IModelInput>(inputDataFilePath, separatorChar, hasHeader, allowQuoting: allowQuoting);
    }


    /// <summary>
    /// Save a model at the specified path.
    /// </summary>
    /// <param name="mlContext">The common context for all ML.NET operations.</param>
    /// <param name="model">Model to save.</param>
    /// <param name="data">IDataView used to train the model.</param>
    /// <param name="modelSavePath">File-path for saving the model.</param>
    private static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
    {
        // Pull the data schema from the IDataView used for training the model
        var dataViewSchema = data.Schema;

        using var fs = File.Create(modelSavePath);
        mlContext.Model.Save(model, dataViewSchema, fs);
    }


    /// <summary>
    /// Retrain model using the pipeline generated as part of the training process.
    /// </summary>
    /// <param name="mlContext">The common context for all ML.NET operations.</param>
    /// <param name="trainData">File to train the model on.</param>
    /// <returns>Retrained Model.</returns>
    private static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
    {
        var pipeline = BuildPipeline(mlContext);
        var model = pipeline.Fit(trainData);

        return model;
    }

    /// <summary>
    /// Build the pipeline used from model builder. Use this function to re-train the model.
    /// </summary>
    /// <param name="mlContext">The common context for all ML.NET operations.</param>
    /// <returns>Build pipeline.</returns>
    private static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
    {
        // Data process configuration with pipeline data transformations
        var pipeline = mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"col0",outputColumnName:@"col0")      
                                .Append(mlContext.Transforms.Concatenate("Features", @"col0"))      
                                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:"col1",inputColumnName:"col1",addKeyValueAnnotationsAsText:false))      
                                .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options {NumberOfLeaves=4,MinimumExampleCountPerLeaf=20,NumberOfTrees=4,MaximumBinCountPerFeature=254,FeatureFraction=1,LearningRate=0.09999999999999998,LabelColumnName="col1",FeatureColumnName="Features",DiskTranspose=false}),labelColumnName: "col1"))      
                                .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:"PredictedLabel",inputColumnName:"PredictedLabel"));

        return pipeline;
    }
}