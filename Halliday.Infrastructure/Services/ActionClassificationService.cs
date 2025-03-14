using Halliday.AI.Models.ActionClassificationModel;
using Halliday.Application.Interfaces;
using Halliday.Application.Models;

namespace Halliday.Infrastructure.Services;

public class ActionClassificationService : ActionClassificationModel, IActionClassificationService
{
    public ModelOutput ClassifyAction(ModelInput input)
    {
        var classificationParams = new ActionClassificationInput
        {
            Col0 = input
        };
        var prediction = Predict(classificationParams);
        return new ModelOutput(
            Value: prediction.PredictedLabel, 
            Score: prediction.Score);
    }
}