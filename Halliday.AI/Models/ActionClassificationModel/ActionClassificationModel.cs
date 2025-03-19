using Halliday.AI.Common;
using Halliday.AI.Common.Interfaces;
using Halliday.AI.Common.Models;
using Microsoft.ML;

namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationModel(string modelRelativePath) : Model(modelRelativePath)
{
    public List<Tuple<string, double>> Evaluate(string label)
    {
        var trainingValues = new TrainingValues
        {
            RelativeTrainingFilePath = "/Data/time-dataset.txt"
        };
        return Evaluate<ActionClassificationInput>("col0", trainingValues);
    }
}