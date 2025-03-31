using UserService.Application.Common.Results;
using UserService.Application.Dtos;
using UserService.Application.Interfaces.User;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Services.User;

public class UserService : IUserService
{
    public async Task<Result<bool>> CreateAsync(IApplicationUser user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UpdateAsync(IApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> DeleteAsync(IApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UpdateClaimsAsync(IApplicationUser user, ClaimUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}