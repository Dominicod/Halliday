namespace Halliday.AI.Common.Interfaces;

public interface IModelOutput
{
    string PredictedLabel { get; set; }
    float[] Score { get; set; }
}