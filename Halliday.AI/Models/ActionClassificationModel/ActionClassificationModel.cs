using Microsoft.ML;

namespace Halliday.AI.Models.ActionClassificationModel;

public class ActionClassificationModel
{
    private readonly Lazy<PredictionEngine<ActionClassificationInput, ActionClassificationOutput>> _predictEngine = new(CreatePredictEngine, true);
    private static readonly string MlNetModelPath = Path.GetFullPath("ActionClassificationModel.mlnet");
    
    private static PredictionEngine<ActionClassificationInput, ActionClassificationOutput> CreatePredictEngine()
    {
        var mlContext = new MLContext();
        var mlModel = mlContext.Model.Load(MlNetModelPath, out _);
        return mlContext.Model.CreatePredictionEngine<ActionClassificationInput, ActionClassificationOutput>(mlModel);
    }

    protected ActionClassificationOutput Predict(ActionClassificationInput input)
    {
        var predEngine = _predictEngine.Value;
        return predEngine.Predict(input);
    }
}