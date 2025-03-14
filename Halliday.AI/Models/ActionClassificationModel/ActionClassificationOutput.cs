using Halliday.AI.Interfaces;
using Microsoft.ML.Data;

namespace Halliday.AI.Models.ActionClassificationModel;

public record ActionClassificationOutput : IModelOutput
{
    [ColumnName("col0")]
    public float[] Col0 { get; set; } = [];

    [ColumnName("col1")] 
    public uint Col1 { get; set; } = 0;

    [ColumnName("Features")]
    public float[] Features { get; set; } = [];

    [ColumnName("PredictedLabel")]
    public string PredictedLabel { get; set; } = string.Empty;

    [ColumnName("Score")]
    public float[] Score { get; set; } = [];
}