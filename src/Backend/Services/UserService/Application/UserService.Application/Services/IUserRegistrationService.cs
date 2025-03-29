using UserService.Application.Dtos;

namespace UserService.Application.Services;

public interface IUserRegistrationService
{
    Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto);
}