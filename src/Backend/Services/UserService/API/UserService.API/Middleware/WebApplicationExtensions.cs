using UserService.Infrastructure.Identity.Data;

namespace UserService.API.Middleware;

public static class WebApplicationExtensions
{
    public static void UseJsonResponseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<JsonResponseExceptionHandlerMiddleware>();
    }

    public static void InitializeDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var servicesProvider = scope.ServiceProvider;
        try
        {
            var context = servicesProvider.GetRequiredService<UserDbContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception exception)
        {
            var logger = servicesProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(exception, "An error occurred while app initialization");
        }
    }
}