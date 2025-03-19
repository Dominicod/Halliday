namespace Halliday.AI.Common.Models;

public record TrainingValues
{
    private readonly string _relativeTrainingFilePath = string.Empty;

    public bool? HasHeader { get; init; } = false;
    
    public bool? AllowQuoting { get; init; } = false;
    
    public char? Separator { get; init; } = ':';
    
    public required string RelativeTrainingFilePath
    {
        get => _relativeTrainingFilePath;
        init 
        {
            if (!Path.IsPathFullyQualified(value))
                throw new ArgumentException("Path must be fully qualified.", nameof(value));
            
            _relativeTrainingFilePath = value;
        }
    }
}