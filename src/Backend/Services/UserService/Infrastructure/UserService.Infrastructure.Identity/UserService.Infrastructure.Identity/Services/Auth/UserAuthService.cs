using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Auth;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Services.Auth;

public class UserAuthService : IUserAuthService
{
    public async Task<Result<bool>> LoginAsync(IApplicationUser user, string password)
    {
        throw new NotImplementedException();
    }
}