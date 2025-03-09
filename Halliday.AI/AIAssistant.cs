using Halliday.AI.Tools;
using LangChain.Chains.StackableChains.Agents.Crew;
using LangChain.Providers;
using LangChain.Providers.Ollama;

namespace Halliday.AI;

public class AIAssistant : IAIAssistant
{
    private readonly Crew _crew;

    protected AIAssistant()
    {
        var provider = new OllamaProvider();
        var model = new OllamaChatModel(provider, id: "llama3.1").UseConsoleForDebug();
        var agent = new CrewAgent(model, "Halliday", "Whenever the User asks for something, look through your list of tools and see if you can find a tool that can help with that. If you can't find a tool, return 'Unavailable'.");
        agent.AddTools([new TimeTool().CrewAgentTool]);
        var agentTask = new AgentTask(agent, "", []);
        _crew = new Crew([agent], [agentTask]);
    }
    
    public async Task Run()
    {
        var res = await _crew.RunAsync();
        Console.WriteLine(res);
    }
}