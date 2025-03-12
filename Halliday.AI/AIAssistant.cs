using Halliday.AI.Models.ActionClassificationModel;

namespace Halliday.AI;

public class AIAssistant : IAIAssistant
{
    public Task Run()
    {
        var model = new ActionClassificationModel();
        var input = new ActionClassificationModel.ModelInput
        {
            Col0 = "What time is it?"
        };
        var output = model.Classify(input);
        var test = "";
        return Task.CompletedTask;
    }
}