namespace UserService.Infrastructure.Identity.Data;

public static class DbInitializer
{
    public static void Initialize(UserDbContext context)
    {
        context.Database.EnsureCreated();
    }
}