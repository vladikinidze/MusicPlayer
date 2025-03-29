using Microsoft.AspNetCore.Identity;
using UserService.Application.Dtos;
using UserService.Application.Exceptions;
using UserService.Application.Services;
using UserService.Infrastructure.Identity.Extensions;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Services;

public class RoleManagementService : IRoleManagementService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleManagementService(RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task AddRolesAsync(IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                {
                    var errors = result.Errors.ToErrorViewModels();
                    throw new AggregateErrorException(errors.ToList());
                }
            }
        }
    }

    public async Task AddRolesToUserAsync(AddRolesToUserDto addRolesToUserDto)
    {
        var user = await _userManager.FindByIdAsync(addRolesToUserDto.UserId);
        if (user is null)
        {
            throw new NotFoundException("User", addRolesToUserDto.UserId);
        }

        var result = await _userManager.AddToRolesAsync(user, addRolesToUserDto.Roles);
        if (!result.Succeeded)
        {
            var errors = result.Errors.ToErrorViewModels();
            throw new AggregateErrorException(errors.ToList());
        }
    }
}