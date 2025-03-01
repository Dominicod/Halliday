using Microsoft.Extensions.DependencyInjection;

namespace Charles.Infrastructure.Extensions;

public static class ApplicationServiceInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}