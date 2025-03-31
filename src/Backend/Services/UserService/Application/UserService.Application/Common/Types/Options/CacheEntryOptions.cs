namespace UserService.Application.Common.Options;

public class CacheEntryOptions
{
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
    public TimeSpan? SlidingExpiration { get; set; }
    
    public static CacheEntryOptions DefaultOptions => new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
    };
}