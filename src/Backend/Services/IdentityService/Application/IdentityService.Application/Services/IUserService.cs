namespace IdentityService.Application.Services;

public interface IUserService
{
    // TODO: add request to get user data and is active methods
    
    Task GetUserDataAsync();
    Task IsActiveAsync();
}