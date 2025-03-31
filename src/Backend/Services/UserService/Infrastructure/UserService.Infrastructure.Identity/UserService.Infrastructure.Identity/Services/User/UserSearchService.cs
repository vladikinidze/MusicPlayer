using UserService.Application.Common.Results;
using UserService.Application.Dtos;
using UserService.Application.Interfaces.User;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Services.User;

public class UserSearchService : IUserSearchService
{
    public async Task<Result<IApplicationUser>> GetByLoginAsync(string login)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IApplicationUser>> GetUserByIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<UserClaimsDto>> GetClaimsAsync(IApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<IApplicationUser>>> GetByIdsAsync(IEnumerable<string> ids)
    {
        throw new NotImplementedException();
    }
}