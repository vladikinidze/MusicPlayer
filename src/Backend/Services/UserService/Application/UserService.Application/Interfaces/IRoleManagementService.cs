using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IRoleManagementService
{
    Task AddRolesAsync(IEnumerable<string> roles);
    Task AddRolesToUserAsync(AddRolesToUserDto addRolesToUserDto);
}