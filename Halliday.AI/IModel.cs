using Halliday.AI.Common.Interfaces;

namespace Halliday.AI;

public interface IModel
{
    public IModelOutput Predict(IModelInput input);
    
    public bool Train();

    public List<Tuple<string, double>> Evaluate(string label);
}