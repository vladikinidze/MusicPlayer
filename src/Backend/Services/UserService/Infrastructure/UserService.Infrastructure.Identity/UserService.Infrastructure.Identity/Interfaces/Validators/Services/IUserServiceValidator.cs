using UserService.Application.Common.Results;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Interfaces.Validators.Services;

public interface IUserServiceValidator
{
    Task<Result> ValidateCreationAsync(IApplicationUser user);
    Task<Result> ValidateUpdateAsync(IApplicationUser user);
    Task<Result> ValidateRemoveAsync(IApplicationUser user);
}