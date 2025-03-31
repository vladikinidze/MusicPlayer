using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Identity.Extensions;

public static class UserManagerExtensions
{
    public static async Task<TUser?> FindByLoginAsync<TUser>(this UserManager<TUser> manager, 
        string login, Func<string, bool> isEmailValidator)
        where TUser : IdentityUser
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            return null;
        }
        TUser? user;
        if (isEmailValidator(login))
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
        if (userIds is null || userIds.TryGetNonEnumeratedCount(out var count) || count == 0)
        {
            return new List<TUser>();
        }
        
        var idSet = new HashSet<string>(userIds);
        return await userManager.Users
            .Where(user => idSet.Contains(user.Id))
            .AsNoTracking()
            .ToListAsync();
    }
}