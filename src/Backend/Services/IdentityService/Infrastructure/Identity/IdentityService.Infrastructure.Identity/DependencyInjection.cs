using IdentityService.Infrastructure.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Infrastructure.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityServerLayer(this IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddInMemoryApiScopes(Configuration.ApiScopes)
            .AddInMemoryClients(Configuration.Clients)
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddProfileService<ProfileService>()
            .AddDeveloperSigningCredential();

        return services;
    }
}