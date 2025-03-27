using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace UserService.Infrastructure.Caching.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task<T?> GetObjectAsync<T>(this IDistributedCache distributedCache, string key)
    {
        var cachedData = await distributedCache.GetStringAsync(key);
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

    public static async Task SetObjectAsync<T>(this IDistributedCache distributedCache, string key, T value,
        DistributedCacheEntryOptions options)
    {
        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), options);
    }
}