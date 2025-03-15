using Halliday.Application.Actions;
using Halliday.Application.Common.Interfaces;

namespace Halliday.Application.Factories;

public class ActionFactory
{
    public IAction? Get(string actionName)
    {
        return actionName switch
        {
            "TimeAction" => new TimeAction(),
            _ => (IAction?)null
        };
    }
}