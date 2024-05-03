using EventHub.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace EventHub.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
            }
        });
        
        return services;
    }
}