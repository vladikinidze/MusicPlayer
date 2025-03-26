using Duende.IdentityModel;
using Duende.IdentityServer.Models;

namespace IdentityService.Infrastructure.Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new("MusicPlayerWebAPI", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "music-player-web-api",
                ClientName = "MusicPlayer Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc",
                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc",
                },
                AllowedScopes =
                {
                    OidcConstants.StandardScopes.OpenId,
                    OidcConstants.StandardScopes.Profile,
                    "MusicPlayerWebAPI"
                },
                AllowAccessTokensViaBrowser = true,
            },
        };
}