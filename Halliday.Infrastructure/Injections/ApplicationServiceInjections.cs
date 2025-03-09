using Microsoft.Extensions.DependencyInjection;

namespace Halliday.Infrastructure.Injections;

public static class ApplicationServiceInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}