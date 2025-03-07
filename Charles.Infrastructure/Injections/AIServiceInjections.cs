using Charles.Application.Interfaces;
using Charles.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Charles.Infrastructure.Injections;

public static class AIServiceInjections
{
    public static IServiceCollection AddAIServices(this IServiceCollection services)
    {
        services.AddScoped<IAI, AIService>();
        
        return services;
    }
}