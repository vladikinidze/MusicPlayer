using Microsoft.AspNetCore.Identity;
using UserService.Application.Extensions;

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
}