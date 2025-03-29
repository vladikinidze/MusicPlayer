using UserService.Application.Dtos;

namespace UserService.Application.Services;

public interface IUserClaimsService
{
    Task<UserClaimsDto> GetUserClaimsAsync(string userId);
}