using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Interfaces.Adapters;

public interface IUserRolesManagerAdapter
{
    Task<Result> AddRolesAsync(IApplicationUser user, IEnumerable<string> roles);
    Task<Result> RemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles);
    Task<Result<IEnumerable<string>>> GetRolesAsync(IApplicationUser user);
}