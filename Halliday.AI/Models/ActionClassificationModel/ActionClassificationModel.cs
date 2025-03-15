using Halliday.AI.Common.Interfaces;
using Microsoft.ML;

namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationModel : IModel
{
    private readonly MLContext _mlContext = new();
    private readonly ITransformer _model;
    private const string MlNetModelPath = "../Halliday.AI/Models/ActionClassificationModel/ActionClassificationModel.mlnet";
    private const string TrainingFilePath =  "../Halliday.AI//Data/time-dataset.txt";
    private const char RetrainSeparatorChar = ':';
    private const bool RetrainHasHeader =  false;
    private const bool RetrainAllowQuoting =  false;

    public ActionClassificationModel()
    {
        _model = _mlContext.Model.Load(MlNetModelPath, out _);
    }
    
    /// <summary>
    /// Creates new prediction engine for the model.
    /// </summary>
    /// <returns>Created prediction engine.</returns>
    private PredictionEngine<ActionClassificationInput, ActionClassificationOutput> CreatePredictEngine()
    {
        return _mlContext.Model.CreatePredictionEngine<ActionClassificationInput, ActionClassificationOutput>(_model);
    }

    /// <summary>
    /// Predict the output of the model given an input.
    /// </summary>
    /// <param name="input">Input to the Model.</param>
    /// <returns>Output of Model.</returns>
    /// <exception cref="ArgumentException">If an invalid input type passed as parameter.</exception>
    public IModelOutput Predict(IModelInput input)
    {
        var actionClassificationInput = input as ActionClassificationInput;
        
        if (actionClassificationInput is null)
            throw new ArgumentException("Invalid input type");
        
        var predEngine = CreatePredictEngine();
        return predEngine.Predict(actionClassificationInput);
    }

    public bool Train()
    {
        try
        {
            Train(outputModelPath: MlNetModelPath,
                inputDataFilePath: TrainingFilePath,
                separatorChar: RetrainSeparatorChar,
                hasHeader: RetrainHasHeader,
                allowQuoting: RetrainAllowQuoting);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    
    public List<Tuple<string, double>> Evaluate(string label)
    {
        var trainData = LoadIDataViewFromFile(
            mlContext: _mlContext,
            inputDataFilePath: TrainingFilePath,
            separatorChar: RetrainSeparatorChar,
            hasHeader: RetrainHasHeader,
            allowQuoting: RetrainAllowQuoting);
        return CalculatePFI(
            mlContext: _mlContext,
            trainData: trainData,
            model: _model,
            labelColumnName: label);
    }
}