using UserService.Application.Common.Results;
using UserService.Application.Dtos;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.User;

public interface IUserSearchService
{
    Task<Result<IApplicationUser>> GetByLoginAsync(string login);
    Task<Result<IApplicationUser>> GetUserByIdAsync(string userId);
    Task<Result<UserClaimsDto>> GetClaimsAsync(IApplicationUser user);
    Task<Result<IEnumerable<IApplicationUser>>> GetByIdsAsync(IEnumerable<string> ids);
}