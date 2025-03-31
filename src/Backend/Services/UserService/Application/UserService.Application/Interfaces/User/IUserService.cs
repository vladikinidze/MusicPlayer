using UserService.Application.Common.Results;
using UserService.Application.Dtos;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.User;

public interface IUserService
{
    Task<Result<bool>> CreateAsync(IApplicationUser user, string password);
    Task<Result<bool>> UpdateAsync(IApplicationUser user);
    Task<Result<bool>> DeleteAsync(IApplicationUser user);
    Task<Result<bool>> UpdateClaimsAsync(IApplicationUser user, ClaimUpdateDto dto);
}