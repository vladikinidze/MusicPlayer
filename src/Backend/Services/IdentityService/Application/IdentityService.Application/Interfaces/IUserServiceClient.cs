using IdentityService.Application.Dtos;

namespace IdentityService.Application.Interfaces;

public interface IUserServiceClient
{
    Task<bool> Login(string login, string password);    
    Task<bool> IsUserActive(string userId);
    Task<UserDto?> GetUserById(string userId);
}