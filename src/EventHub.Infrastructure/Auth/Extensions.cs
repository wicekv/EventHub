using System.Text;
using EventHub.Application.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EventHub.Infrastructure.Auth;

internal static class Extensions
{
    private const string OptionsSectionName = "auth";

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<AuthOptions>(OptionsSectionName);

        services
            .Configure<AuthOptions>(configuration.GetRequiredSection(OptionsSectionName))
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<ITokenStorage, HttpContextTokenStorage>()
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "Bearer";
                o.DefaultScheme = "Bearer";
                o.DefaultChallengeScheme = "Bearer";
            })
            .AddJwtBearer(o =>
            {
                o.Audience = options.Audience;
                o.IncludeErrorDetails = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                };
            });

        return services;
    }
}