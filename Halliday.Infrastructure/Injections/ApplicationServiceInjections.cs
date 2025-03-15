using Halliday.Application.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Halliday.Infrastructure.Injections;

public static class ApplicationServiceInjections
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ActionFactory>();
    }
}