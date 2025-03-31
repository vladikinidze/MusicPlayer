using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.Roles;
    
public interface IUserRoleService
{
    Task<Result> AddRolesAsync(IApplicationUser user, IEnumerable<string> roles);
    Task<Result> RemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles);
    Task<Result<IEnumerable<string>>> GetRolesAsync(IApplicationUser user);
}   