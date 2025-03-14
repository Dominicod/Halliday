using Halliday.AI.Interfaces;

namespace Halliday.AI;

public interface IModel
{
    public IModelOutput Predict(IModelInput input);
}