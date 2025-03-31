using UserService.Application.Common.Results;

namespace UserService.Application.Interfaces.Roles;

public interface IRoleService
{
    Task<Result<bool>> CreateRoleAsync(string roleName);
    Task<Result<bool>> DeleteRoleAsync(string roleName);
    Task<Result<bool>> UpdateRoleNameAsync(string oldName, string newName);
    Task<Result<IEnumerable<string>>> GetAllRolesAsync();
}