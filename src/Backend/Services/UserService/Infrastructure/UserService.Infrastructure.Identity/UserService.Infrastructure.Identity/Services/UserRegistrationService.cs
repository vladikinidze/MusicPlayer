using Microsoft.AspNetCore.Identity;
using UserService.Application.Dtos;
using UserService.Application.Exceptions;
using UserService.Application.Services;
using UserService.Infrastructure.Identity.Extensions;
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
        var creationResult = await _userManager.CreateAsync(applicationUser, registerUserDto.Password);
        if (!creationResult.Succeeded)
        {
            var errors = creationResult.Errors.ToErrorViewModels();
            throw new AggregateErrorException(errors.ToList());
        }
        
        return creationResult.Succeeded;
    }
}