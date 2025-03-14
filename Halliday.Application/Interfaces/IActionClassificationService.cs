using Halliday.Application.Models;

namespace Halliday.Application.Interfaces;

public interface IActionClassificationService
{
    ModelOutput ClassifyAction(ModelInput input);
}