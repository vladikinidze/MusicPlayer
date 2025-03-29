using UserService.Application.Options;

namespace UserService.Application.Services;

public interface ICacheService
{
    Task<T?> GetObjectAsync<T>(string key); 
    Task<Dictionary<string, T>> GetObjectsAsync<T>(IEnumerable<string> keys, Func<string, string> keyResolver);
    Task SetObjectAsync<T>(string key, T value, CacheEntryOptions options);
    Task SetObjectsAsync<T>(IEnumerable<T> objects, Func<T, string> keyResolver, CacheEntryOptions options);
    Task RemoveAsync(string key);
}   