using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IUserAuthenticationService
{
    Task<bool> LoginUserAsync(LoginUserDto loginUserDto);
    Task<bool> ValidateCredentialsAsync(LoginUserDto loginUserDto);
}