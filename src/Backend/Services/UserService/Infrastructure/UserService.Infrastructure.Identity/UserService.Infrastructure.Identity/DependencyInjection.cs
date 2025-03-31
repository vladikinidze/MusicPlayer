using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Infrastructure.Identity.Adapters;
using UserService.Infrastructure.Identity.Data;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Models;

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

        services.AddSingleton<IUserCaster, UserCaster>();
        
        return services;
    }
}