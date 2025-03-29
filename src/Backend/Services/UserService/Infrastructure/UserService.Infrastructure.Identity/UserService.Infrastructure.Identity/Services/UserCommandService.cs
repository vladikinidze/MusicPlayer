using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Infrastructure.Identity.Services;

public class UserCommandService : IUserCommandService
{
    public Task<bool> UpdateUserAsync(UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}