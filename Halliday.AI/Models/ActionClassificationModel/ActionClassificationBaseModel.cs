using Halliday.AI.Common;
using Halliday.AI.Common.Models;

namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationBaseModel(string modelRelativePath) : BaseModel(modelRelativePath), IModel
{
    public List<Tuple<string, double>> Evaluate(string label)
    {
        var trainingValues = new TrainingValues
        {
            RelativeTrainingFilePath = "/Data/time-dataset.txt"
        };
        return Evaluate<ActionClassificationInput>(label, trainingValues);
    }
}