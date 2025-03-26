using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UserService.Application.Dtos;
using UserService.Application.Exceptions;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserClaimsService : IUserClaimsService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserClaimsService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<UserClaimsDto> GetUserClaimsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException("User", userId);
        }

        var claimsTask = _userManager.GetClaimsAsync(user);
        var rolesTask = _userManager.GetRolesAsync(user);

        await Task.WhenAll(claimsTask, rolesTask);

        var claims = claimsTask.Result
            .Select(claim => new ClaimDto(claim.Type, claim.Value))
            .ToList();

        var roles = rolesTask.Result.ToList();
        
        var result = new UserClaimsDto(user.Id, roles, claims);
        
        return result;
    }
}