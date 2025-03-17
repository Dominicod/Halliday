using Microsoft.ML;

namespace Halliday.AI.Common;

public abstract class Model<TInput, TOutput> where TInput : class, new() where TOutput : class, new()
{
    private char _retrainSeparatorChar = ':';
    private bool _retrainHasHeader = false;
    private bool _retrainAllowQuoting = false;
    private string _modelPath = string.Empty;
    private string _trainingPath = string.Empty;
    private readonly MLContext _mlContext = new();
    protected PredictionEngine<TInput, TOutput>? PredictionEngine;

    protected Model(string mlnetFileName)
    {
        _modelPath = GetMlNetModelPath(mlnetFileName);
        var transformer = _mlContext.Model.Load(_modelPath, out _);
        // PredictionEngine = _mlContext.Model.CreatePredictionEngine<TInput, TOutput>(transformer);
    }

    private static string GetMlNetModelPath(string mlnetFileName)
    {
        return string.Empty;
    }
}