using Halliday.AI.Common.Interfaces;

namespace Halliday.AI;

public interface IModel
{
    public IModelOutput Predict(IModelInput input);
}