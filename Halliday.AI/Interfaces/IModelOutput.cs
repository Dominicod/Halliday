namespace Halliday.AI.Interfaces;

public interface IModelOutput
{
    string PredictedLabel { get; set; }
    float[] Score { get; set; }
}