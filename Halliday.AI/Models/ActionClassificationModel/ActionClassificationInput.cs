using Halliday.AI.Interfaces;
using Microsoft.ML.Data;

namespace Halliday.AI.Models.ActionClassificationModel;

public record ActionClassificationInput : IModelInput
{
    [LoadColumn(0)]
    [ColumnName("col0")]
    public string Col0 { get; set; } = string.Empty;
    
    [LoadColumn(1)]
    [ColumnName("col1")]
    public string Col1 { get; set; } = string.Empty;
}