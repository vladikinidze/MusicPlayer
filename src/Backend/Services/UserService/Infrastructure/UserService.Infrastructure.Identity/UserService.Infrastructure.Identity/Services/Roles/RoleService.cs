using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Roles;

namespace UserService.Infrastructure.Identity.Services.Roles;

public class RoleService : IRoleService
{
    public async Task<Result<bool>> CreateRoleAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> DeleteRoleAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UpdateRoleNameAsync(string oldName, string newName)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<string>>> GetAllRolesAsync()
    {
        throw new NotImplementedException();
    }
}