using Microsoft.AspNetCore.Identity;
using UserService.Application.Dtos;
using UserService.Application.Exceptions;
using UserService.Application.Interfaces;
using UserService.Application.ViewModels;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRegistrationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = registerUserDto.UserName,
            Email = registerUserDto.Email,
            RegisteredAt = DateTime.UtcNow,
        };
        var result = await _userManager.CreateAsync(applicationUser, registerUserDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .Select(error => new ErrorViewModel("_", error.Description))
                .ToList();
            throw new ManyErrorsException(errors);
        }

        await _userManager.AddToRoleAsync(applicationUser, "user");
        return result.Succeeded;
    }
}