namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationModel
{
    public ModelOutput Classify(ModelInput input) => Predict(input);
}