using Halliday.Application.Interfaces;

namespace Halliday.Application;

public class TestService(IAIAssistant assistant)
{
    public void Run() => assistant.Run();
}