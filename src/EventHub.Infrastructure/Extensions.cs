using EventHub.Core.Abstractions;
using EventHub.Core.Repositories;
using EventHub.Infrastructure.DAL;
using EventHub.Infrastructure.DAL.Repositories;
using EventHub.Infrastructure.Middlewares;
using EventHub.Infrastructure.Security;
using EventHub.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventHub.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppOptions>(configuration.GetRequiredSection("app")); 
        services.AddSingleton<ExceptionMiddleware>(); 
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddHttpContextAccessor();
        
        services
            .AddPostgres(configuration)
            .AddSingleton<IClock, Clock>();
        
        services.AddSecurity();

        return services;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}