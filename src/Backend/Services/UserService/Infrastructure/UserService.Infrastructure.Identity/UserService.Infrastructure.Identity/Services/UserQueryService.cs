using Microsoft.AspNetCore.Identity;
using UserService.Application.Exceptions;
using UserService.Application.Options;
using UserService.Application.Services;
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
        var cachedUsers = await _cacheService.GetObjectsAsync<ApplicationUser>(userIds, GetUserCacheKey);
        var missingIds = userIds.Except(cachedUsers.Keys).ToList();
        if (missingIds.Count != 0)
        {
            var dbUsers = await _userManager.GetUsersByIdsAsync(missingIds);
            await _cacheService.SetObjectsAsync(dbUsers, user => GetUserCacheKey(user.Id), CacheEntryOptions.DefaultOptions);
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
            throw new AggregateErrorException(errors);
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

    private string GetUserCacheKey(string key) => $"app:user:{key}";
}