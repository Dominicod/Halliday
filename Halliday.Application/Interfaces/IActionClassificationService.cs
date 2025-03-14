using Halliday.Domain.ValueObjects;

namespace Halliday.Application.Interfaces;

public interface IActionClassificationService
{
    ModelOutput ClassifyAction(ModelInput input);
}