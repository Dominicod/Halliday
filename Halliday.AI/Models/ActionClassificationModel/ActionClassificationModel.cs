using Halliday.AI.Common.Interfaces;
using Microsoft.ML;

namespace Halliday.AI.Models.ActionClassificationModel;

public class ActionClassificationModel : IModel
{
    private readonly Lazy<PredictionEngine<ActionClassificationInput, ActionClassificationOutput>> _predictEngine = new(CreatePredictEngine, true);
    private static readonly string MlNetModelPath = Path.GetFullPath("ActionClassificationModel.mlnet");
    
    private static PredictionEngine<ActionClassificationInput, ActionClassificationOutput> CreatePredictEngine()
    {
        var mlContext = new MLContext();
        var mlModel = mlContext.Model.Load(MlNetModelPath, out _);
        return mlContext.Model.CreatePredictionEngine<ActionClassificationInput, ActionClassificationOutput>(mlModel);
    }

    public IModelOutput Predict(IModelInput input)
    {
        var actionClassificationInput = input as ActionClassificationInput;
        
        if (actionClassificationInput is null)
            throw new ArgumentException("Invalid input type");
        
        var predEngine = _predictEngine.Value;
        return predEngine.Predict(actionClassificationInput);
    }
}