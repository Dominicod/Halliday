using LangChain.Chains.StackableChains.Agents.Crew.Tools;

namespace Halliday.AI.Tools;

public class TimeTool : ITool
{
    public CrewAgentToolLambda CrewAgentTool { get; private init; } = new("ping", "executes ping on specified ip address", Task.FromResult);
}