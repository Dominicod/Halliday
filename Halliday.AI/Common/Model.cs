using Microsoft.ML;

namespace Halliday.AI.Common;

public abstract class Model
{
    private string _modelPath;
    private readonly MLContext _mlContext = new();

    protected Model(string modelRelativePath)
    {
        _modelPath = GetMlNetModelPath(modelRelativePath);
        // var transformer = _mlContext.Model.Load(_modelPath, out _);
    }

    private static string GetMlNetModelPath(string relativePath)
    {
        if (!relativePath.EndsWith(".mlnet"))
            throw new ArgumentException("File must end with '.mlnet'");

        return FormatPath(relativePath);
    }

    private static string GetTrainModelPath(string relativePath)
    {
        if (!relativePath.EndsWith(".txt"))
            throw new ArgumentException("File must end with '.txt'");

        return FormatPath(relativePath);
    }

    private static string FormatPath(string path)
    {
        // Pulls Path out of bin directory
        var modifiedPath = $"../../../{path}";
        var fullPath = Path.GetFullPath(modifiedPath);
        
        // When running Web project the full path uses Web due to it being
        // the applications current entry point
        if (fullPath.Contains("Halliday.Web"))
            fullPath = fullPath.Replace("Halliday.Web", "Halliday.AI");

        return fullPath;
    }
}