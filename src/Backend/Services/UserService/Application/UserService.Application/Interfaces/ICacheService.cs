using UserService.Application.Options;

namespace UserService.Application.Interfaces;

public interface ICacheService
{
    Task<T?> GetObjectAsync<T>(string key);
    Task SetObjectAsync<T>(string key, T value, CacheEntryOptions options);
    Task RemoveAsync(string key);
}   