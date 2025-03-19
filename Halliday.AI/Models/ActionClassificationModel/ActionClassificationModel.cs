using Halliday.AI.Common;
using Halliday.AI.Common.Interfaces;
using Microsoft.ML;

namespace Halliday.AI.Models.ActionClassificationModel;

public partial class ActionClassificationModel(string modelRelativePath) : Model(modelRelativePath)
{
    // /// <summary>
    // /// Predict the output of the model given an input.
    // /// </summary>
    // /// <param name="input">Input to the Model.</param>
    // /// <returns>Output of Model.</returns>
    // /// <exception cref="ArgumentException">If an invalid input type passed as parameter.</exception>
    // public IModelOutput Predict(IModelInput input)
    // {
    //     var actionClassificationInput = input as ActionClassificationInput;
    //     
    //     if (actionClassificationInput is null)
    //         throw new ArgumentException("Invalid input type");
    //     
    //     var predEngine = CreatePredictEngine();
    //     return predEngine.Predict(actionClassificationInput);
    // }
    //
    // public bool Train()
    // {
    //     try
    //     {
    //         Train(outputModelPath: _mlNetModelPath,
    //             inputDataFilePath: _trainingFilePath,
    //             separatorChar: RetrainSeparatorChar,
    //             hasHeader: RetrainHasHeader,
    //             allowQuoting: RetrainAllowQuoting);
    //
    //         return true;
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //         return false;
    //     }
    // }
    //
    // public List<Tuple<string, double>> Evaluate(string label)
    // {
    //     var trainData = LoadIDataViewFromFile(
    //         mlContext: _mlContext,
    //         inputDataFilePath: _trainingFilePath,
    //         separatorChar: RetrainSeparatorChar,
    //         hasHeader: RetrainHasHeader,
    //         allowQuoting: RetrainAllowQuoting);
    //     return CalculatePFI(
    //         mlContext: _mlContext,
    //         trainData: trainData,
    //         model: _model,
    //         labelColumnName: label);
    // }
}