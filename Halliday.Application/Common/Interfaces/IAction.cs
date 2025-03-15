using Halliday.Domain.ValueObjects;

namespace Halliday.Application.Common.Interfaces;

public interface IAction
{
    public object Execute();
    
    public UserAnswer ParseResponse(object input);
}