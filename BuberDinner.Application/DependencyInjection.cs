using BuberDinner.Application.Common.Services.Authentication.Commands;
using BuberDinner.Application.Common.Services.Authentication.Queries;
using BuberDinner.Application.Services.Authentication.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}
