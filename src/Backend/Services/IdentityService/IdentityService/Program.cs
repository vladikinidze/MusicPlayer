using IdentityService;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AccountDbContext>(options => { options.UseNpgsql(connectionString); });

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(config =>
    {
        config.Password.RequiredLength = 7;
        config.Password.RequireDigit = true;
        config.Password.RequireNonAlphanumeric = true;
        config.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<AccountDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "MusicPlayer.Identity.Cookie";
    config.LoginPath = "/login";
    config.LogoutPath = "/logout";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
try
{
    var context = provider.GetRequiredService<AccountDbContext>();
    Initializer.Initialize(context);
}
catch (Exception exception)
{
    var logger = provider.GetRequiredService<ILogger<Program>>();
    logger.LogError(exception, "An error occurred while app initialization");
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "Styles")),
    RequestPath = "/styles",
});
app.UseRouting();
app.UseIdentityServer();
app.MapDefaultControllerRoute();
app.Run();