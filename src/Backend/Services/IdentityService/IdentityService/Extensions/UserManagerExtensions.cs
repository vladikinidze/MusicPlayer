using Microsoft.AspNetCore.Identity;

namespace IdentityService.Extensions;

public static class UserManagerExtensions
{
    public static async Task<TUser?> FindByEmailOrUserName<TUser>(this UserManager<TUser> manager, string login)
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