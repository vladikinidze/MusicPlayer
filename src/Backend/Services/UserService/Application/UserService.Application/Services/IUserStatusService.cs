
namespace UserService.Application.Services;

public interface IUserStatusService
{
    Task<bool> IsUserActiveAsync(string userId);
}