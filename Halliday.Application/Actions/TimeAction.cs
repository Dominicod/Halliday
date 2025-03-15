using Halliday.Application.Common.Interfaces;
using Halliday.Domain.ValueObjects;

namespace Halliday.Application.Actions;

internal class TimeAction : IAction
{
    public object Execute() => DateTime.Now;
    
    public UserAnswer ParseResponse(object input)
    {
        var time = input.ToString();
        
        return new UserAnswer($"The time is {time}");
    }
}