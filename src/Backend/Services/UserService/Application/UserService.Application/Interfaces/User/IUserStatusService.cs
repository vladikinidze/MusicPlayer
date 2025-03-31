using UserService.Application.Common.Results;

namespace UserService.Application.Interfaces.User;

public interface IUserStatusService
{
    Task<Result<bool>> IsActiveAsync(Guid userId);
}