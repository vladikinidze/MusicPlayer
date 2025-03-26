namespace UserService.Application.Interfaces;

public interface IUserStatusService
{
    Task<bool> IsUserActiveAsync(string userId);
}