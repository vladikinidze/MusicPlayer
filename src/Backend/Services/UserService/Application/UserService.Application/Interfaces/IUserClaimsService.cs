using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IUserClaimsService
{
    Task<UserClaimsDto> GetUserClaimsAsync(string userId);
}