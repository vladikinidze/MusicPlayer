using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using UserService.Application.Interfaces;
using UserService.Application.Options;

namespace UserService.Infrastructure.Caching;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    
    public async Task<T?> GetObjectAsync<T>(string key)
    {
        var cachedData = await _distributedCache.GetStringAsync(HashKey(key));
        if (cachedData is not null)
        {
            var cachedUser = JsonSerializer.Deserialize<T>(cachedData);
            if (cachedUser is not null)
            {
                return cachedUser;
            }
        }

        return default;
    }

    public async Task SetObjectAsync<T>(string key, T value, CacheEntryOptions options)
    {
        await _distributedCache.SetStringAsync(HashKey(key), JsonSerializer.Serialize(value), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
            SlidingExpiration = options.SlidingExpiration,
        });
    }

    public async Task RemoveAsync(string key)
    {
        await _distributedCache.RemoveAsync(HashKey(key));
    }
    
    private string HashKey(string key)
    {
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        return Convert.ToBase64String(hashBytes).Replace("/", "_").Replace("+", "-");
    }
}