namespace IdentityService.Data;

public static class Initializer
{
    public static void Initialize(AccountDbContext context)
    {
        context.Database.EnsureCreated();
    }
}