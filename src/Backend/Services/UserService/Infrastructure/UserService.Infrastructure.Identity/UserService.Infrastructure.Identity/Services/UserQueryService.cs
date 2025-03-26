using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Exceptions;
using UserService.Application.Interfaces;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Extensions;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserQueryService : IUserQueryService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserQueryService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IApplicationUser> FindByEmailOrUserNameAsync(string login)
    {
        var user = await _userManager.FindByEmailOrUserNameAsync(login);
        if (user is null)
        {
            throw new NotFoundException("User", login);
        }

        return user;
    }

    public async Task<IEnumerable<IApplicationUser>> FindUsersByIdAsync(IEnumerable<string> ids)
    {
        var users = await _userManager.Users
            .Where(user => ids.Contains(user.Id))
            .ToListAsync();
        return users;
    }
}