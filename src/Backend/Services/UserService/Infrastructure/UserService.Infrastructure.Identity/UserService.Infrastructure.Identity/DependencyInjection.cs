using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Services;
using UserService.Infrastructure.Identity.Data;
using UserService.Infrastructure.Identity.Models;
using UserService.Infrastructure.Identity.Services;

namespace UserService.Infrastructure.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddUserIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;   
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddTransient<IRoleManagementService, RoleManagementService>();
        services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
        services.AddTransient<IUserQueryService, UserQueryService>();
        services.AddTransient<IUserRegistrationService, UserRegistrationService>();
        services.AddTransient<IUserStatusService, UserStatusService>();
        services.AddTransient<IUserClaimsService, UserClaimsService>();
        services.AddTransient<IUserCommandService, UserCommandService>();
        
        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "music.web.api";
            config.LoginPath = "/login";
            config.LogoutPath = "/logout";
        });
        
        return services;
    }
}