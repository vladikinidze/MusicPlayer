using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityService.Application.Interfaces;

namespace IdentityService.Infrastructure.Identity.Services;

public class ProfileService : IProfileService
{
    private readonly IUserServiceClient _userServiceClient;

    public ProfileService(IUserServiceClient userServiceClient)
    {
        _userServiceClient = userServiceClient;
    }
    
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var userId = context.Subject.GetSubjectId();
        var user = await _userServiceClient.GetUserById(userId);
        if (user is not null)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
            };
                
            context.IssuedClaims.AddRange(claims);
        }
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var userId = context.Subject.GetSubjectId();
        context.IsActive = await _userServiceClient.IsUserActive(userId);
    }
}