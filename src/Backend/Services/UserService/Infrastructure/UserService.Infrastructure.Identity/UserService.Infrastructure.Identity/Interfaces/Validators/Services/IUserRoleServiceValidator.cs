using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Interfaces.Validators.Services;

public interface IUserRoleServiceValidator
{
    Task<Result> ValidateAddRolesAsync(IApplicationUser user, IEnumerable<string> roles);
    Task<Result> ValidateRemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles);
}