using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IUserRegistrationService
{
    Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto);
}