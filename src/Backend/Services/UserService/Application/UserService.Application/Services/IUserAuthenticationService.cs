using UserService.Application.Dtos;

namespace UserService.Application.Services;

public interface IUserAuthenticationService
{
    Task<bool> LoginUserAsync(LoginUserDto loginUserDto);
    Task<bool> ValidateCredentialsAsync(LoginUserDto loginUserDto);
}