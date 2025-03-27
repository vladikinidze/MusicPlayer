using UserService.Domain.Models;

namespace UserService.Application.Interfaces;

public interface IUserQueryService
{
    Task<IApplicationUser> FindByEmailOrUserNameAsync(string login);
    Task<IEnumerable<IApplicationUser>> FindUsersByIdAsync(IEnumerable<string> ids);
    Task<IApplicationUser> FindUserByIdAsync(string userId);
}