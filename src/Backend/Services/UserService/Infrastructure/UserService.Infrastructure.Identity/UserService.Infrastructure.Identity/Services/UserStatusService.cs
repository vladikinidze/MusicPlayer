using Microsoft.AspNetCore.Identity;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserStatusService : IUserStatusService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserStatusService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> IsUserActiveAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user is not null && !await _userManager.IsLockedOutAsync(user);
    }
}