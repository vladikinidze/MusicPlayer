using UserService.Application.Common.Results;
using UserService.Application.Interfaces.User;

namespace UserService.Infrastructure.Identity.Services.User;

public class UserStatusService : IUserStatusService
{
    public async Task<Result<bool>> IsActiveAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}