using Halliday.AI.Models.ActionClassificationModel;

namespace Halliday.AI;

public class AIAssistant : IAIAssistant
{
    public Task Run()
    {
        var model = new ActionClassificationModel();
        var input = new ActionClassificationInput
        {
            Col0 = "What time is it?"
        };
        var output = model.Predict(input);
        return Task.CompletedTask;
    }
}