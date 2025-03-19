using Halliday.Application.Interfaces;
using Halliday.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Halliday.Infrastructure.Injections;

public static class InfrastructureServiceInjections
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IActionClassificationService, ActionClassificationBaseService>();
    }
}