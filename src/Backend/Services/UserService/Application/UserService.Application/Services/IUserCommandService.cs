using UserService.Application.Dtos;

namespace UserService.Application.Services;

public interface IUserCommandService
{
    Task<bool> UpdateUserAsync(UpdateUserDto updateUserDto);
    Task<bool> DeleteUserAsync(string userId);
}