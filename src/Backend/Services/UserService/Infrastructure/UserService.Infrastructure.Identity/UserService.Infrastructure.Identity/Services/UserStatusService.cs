using Microsoft.AspNetCore.Identity;
using UserService.Application.Services;
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
        var result = user is not null && !await _userManager.IsLockedOutAsync(user);
        return result;
    }
}