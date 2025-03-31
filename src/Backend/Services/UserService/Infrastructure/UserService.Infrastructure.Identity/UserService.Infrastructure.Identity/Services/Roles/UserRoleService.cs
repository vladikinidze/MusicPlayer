using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Roles;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Interfaces.Adapters;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Interfaces.Validators.Services;

namespace UserService.Infrastructure.Identity.Services.Roles;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRolesManagerAdapter _userRolesManagerAdapter;
    private readonly IUserRoleServiceValidator _userRoleServiceValidator;

    public UserRoleService(IUserRolesManagerAdapter userRolesManagerAdapter,
        IUserRoleServiceValidator userRoleServiceValidator)
    {
        _userRolesManagerAdapter = userRolesManagerAdapter;
        _userRoleServiceValidator = userRoleServiceValidator;
    }
    
    public async Task<Result> AddRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        var addRoles = roles.ToList();
        var validationResult = await _userRoleServiceValidator.ValidateAddRolesAsync(user, addRoles);
        if (!validationResult.IsSuccess)
        {
            return Result.Failure(validationResult.Errors!);
        }
        return await _userRolesManagerAdapter.AddRolesAsync(user, addRoles);
    }

    public async Task<Result> RemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        var removeRoles = roles.ToList();
        var validationResult = await _userRoleServiceValidator.ValidateRemoveRolesAsync(user, removeRoles);
        if (!validationResult.IsSuccess)
        {
            return Result.Failure(validationResult.Errors!);
        }
        return await _userRolesManagerAdapter.RemoveRolesAsync(user, removeRoles);
    }

    public async Task<Result<IEnumerable<string>>> GetRolesAsync(IApplicationUser user)
    {
        return await _userRolesManagerAdapter.GetRolesAsync(user);
    }
}