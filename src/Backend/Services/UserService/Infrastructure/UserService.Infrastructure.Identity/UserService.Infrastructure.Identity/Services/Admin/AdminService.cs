using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Admin;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Services.Admin;

public class AdminService : IAdminService
{
    public async Task<Result<bool>> IsLastAdminAsync(IApplicationUser user)
    {
        throw new NotImplementedException();
    }
}