using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Extensions;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Extensions;

public static class UserManagerExtensions
{
    public static async Task<TUser?> FindByEmailOrUserNameAsync<TUser>(this UserManager<TUser> manager, string login)
        where TUser : IdentityUser
    {
        TUser? user;
        if (login.IsEmail())
        {
            user = await manager.FindByEmailAsync(login);
        }
        else
        {
            user = await manager.FindByNameAsync(login);
        }
        
        return user;
    }

    public static async Task<IList<TUser>> GetUsersByIdsAsync<TUser>(
        this UserManager<TUser> userManager, IEnumerable<string> userIds)
        where TUser : IdentityUser
    {
        return await userManager.Users
            .Where(user => userIds.Contains(user.Id))
            .ToListAsync();
    }
}