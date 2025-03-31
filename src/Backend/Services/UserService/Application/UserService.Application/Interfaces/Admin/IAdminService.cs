using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.Admin;

public interface IAdminService
{
    Task<Result<bool>> IsLastAdminAsync(IApplicationUser user);
}