using Microsoft.AspNetCore.Identity;
using UserService.Application.Dtos;
using UserService.Application.Services;
using UserService.Infrastructure.Identity.Extensions;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserAuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginUserAsync(LoginUserDto loginUserDto)
    {
        var user = await _userManager.FindByEmailOrUserNameAsync(loginUserDto.Login);
        if (user == null)
        {
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, true, false);
        return result.Succeeded;
    }

    public async Task<bool> ValidateCredentialsAsync(LoginUserDto loginUserDto)
    {
        var user = await _userManager.FindByEmailOrUserNameAsync(loginUserDto.Login);
        if (user == null)
        {
            return false;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
        return result.Succeeded;
    }
}