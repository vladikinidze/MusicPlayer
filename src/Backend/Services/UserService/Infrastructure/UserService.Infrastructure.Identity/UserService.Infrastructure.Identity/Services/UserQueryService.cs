using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Exceptions;
using UserService.Application.Interfaces;
using UserService.Application.Options;
using UserService.Application.ViewModels;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Extensions;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserQueryService : IUserQueryService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICacheService _cacheService;

    public UserQueryService(UserManager<ApplicationUser> userManager, ICacheService cacheService)
    {
        _userManager = userManager;
        _cacheService = cacheService;
    }

    public async Task<IApplicationUser> FindByEmailOrUserNameAsync(string login)
    {
        var cacheKey = GetUserCacheKey(login);
        var cachedUser = await _cacheService.GetObjectAsync<ApplicationUser>(cacheKey);
        if (cachedUser is not null)
        {
            return cachedUser;
        }

        var user = await _userManager.FindByEmailOrUserNameAsync(login);
        if (user is null)
        {
            throw new NotFoundException("User", login);
        }

        await _cacheService.SetObjectAsync(cacheKey, user, CacheEntryOptions.DefaultOptions);

        return user;
    }

    public async Task<IEnumerable<IApplicationUser>> FindUsersByIdAsync(IEnumerable<string> ids)
    {
        var userIds = ids.ToList();
        var cachedUsers = await GetCachedUsersAsync(userIds);
        var missingIds = userIds.Except(cachedUsers.Keys).ToList();
        if (missingIds.Count != 0)
        {
            var dbUsers = await GetUsersFromDatabaseAsync(missingIds);
            await SaveUsersToCacheAsync(dbUsers);
            foreach (var user in dbUsers)
            {
                cachedUsers[user.Id] = user;
            }
        }

        var errors = userIds
            .Where(userId => !cachedUsers.ContainsKey(userId))
            .Select(userId => new ErrorViewModel(nameof(userId), $"User with key = {userId} not found"))
            .ToList();
        if (errors.Count != 0)
        {
            throw new ManyErrorsException(errors);
        }

        return userIds.Select(id => cachedUsers[id]);
    }

    public async Task<IApplicationUser> FindUserByIdAsync(string userId)
    {
        var cacheKey = GetUserCacheKey(userId);
        var cachedUser = await _cacheService.GetObjectAsync<ApplicationUser>(cacheKey);
        if (cachedUser is not null)
        {
            return cachedUser;
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException("User", userId);
        }

        await _cacheService.SetObjectAsync(cacheKey, user, CacheEntryOptions.DefaultOptions);

        return user;
    }


    private async Task<Dictionary<string, ApplicationUser>> GetCachedUsersAsync(IEnumerable<string> ids)
    {
        var result = new Dictionary<string, ApplicationUser>();
        foreach (var id in ids)
        {
            var cacheKey = GetUserCacheKey(id);
            var user = await _cacheService.GetObjectAsync<ApplicationUser>(cacheKey);
            if (user is not null)
            {
                result.Add(id, user);
            }
        }

        return result;
    }

    private async Task<List<ApplicationUser>> GetUsersFromDatabaseAsync(IEnumerable<string> ids)
    {
        return await _userManager.Users
            .Where(user => ids.Contains(user.Id))
            .ToListAsync();
    }

    private async Task SaveUsersToCacheAsync(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            var cacheKey = GetUserCacheKey(user.Id);
            await _cacheService.SetObjectAsync(cacheKey, user, CacheEntryOptions.DefaultOptions);
        }
    }

    private string GetUserCacheKey(string key) => $"app:user:{key}";
}