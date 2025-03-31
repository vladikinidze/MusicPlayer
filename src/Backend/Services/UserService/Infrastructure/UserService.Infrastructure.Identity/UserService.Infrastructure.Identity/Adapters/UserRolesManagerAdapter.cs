using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Converters;
using UserService.Application.Common.Results;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Interfaces.Adapters;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Adapters;

internal class UserRolesManagerAdapter : BaseUserAdapter, IUserRolesManagerAdapter
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRolesManagerAdapter(IUserCaster caster,
        UserManager<ApplicationUser> userManager,
        IErrorToResultConverter<IdentityError> errorToResultConverter)
        : base(caster, errorToResultConverter)
    {
        _userManager = userManager;
    }

    public async Task<Result> AddRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        return await ExecuteOperationAsync(
            (userManager, applicationUser) => userManager.AddToRolesAsync(applicationUser, roles),
            _userManager,
            user);
    }

    public async Task<Result> RemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        return await ExecuteOperationAsync(
            (userManager, applicationUser) => userManager.RemoveFromRolesAsync(applicationUser, roles),
            _userManager,
            user);
    }

    public async Task<Result<IEnumerable<string>>> GetRolesAsync(IApplicationUser user)
    {
        var applicationUser = CastUser(user);
        var userRoles = await _userManager.GetRolesAsync(applicationUser);
        return Result<IEnumerable<string>>.Success(userRoles);
    }
}