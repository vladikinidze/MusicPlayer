using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.Auth;

public interface IUserAuthService
{
    Task<Result<bool>> LoginAsync(IApplicationUser user, string password);
}