using Halliday.Application.Interfaces;
using Halliday.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Halliday.Infrastructure.Injections;

public static class InfrastructureServiceInjections
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IAIAssistant, AIService>();
        
        return services;
    }
}