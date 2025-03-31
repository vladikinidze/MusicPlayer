using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Converters;
using UserService.Application.Common.Results;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Adapters;

internal abstract class BaseUserAdapter
{
    private readonly IUserCaster _caster;
    private readonly IErrorToResultConverter<IdentityError> _errorToResultConverter;

    protected BaseUserAdapter(IUserCaster caster,
        IErrorToResultConverter<IdentityError> errorToResultConverter)
    {
        _caster = caster;
        _errorToResultConverter = errorToResultConverter;
    }

    protected ApplicationUser CastUser(IApplicationUser domainUser)
    {
        return _caster.CastToApplicationUser(domainUser);
    }

    protected async Task<Result> ExecuteOperationAsync(
        Func<UserManager<ApplicationUser>, ApplicationUser, Task<IdentityResult>> operation,
        UserManager<ApplicationUser> userManager,
        IApplicationUser user)
    {
        var applicationUser = CastUser(user);
        var result = await operation(userManager, applicationUser);
        return result.Succeeded
            ? Result.Success()
            : _errorToResultConverter.Convert(result.Errors);
    }
    
    protected async Task<Result> ExecuteOperationAsync(
        Func<UserManager<ApplicationUser>, ApplicationUser, Task<IdentityResult>> operation,
        UserManager<ApplicationUser> userManager,
        ApplicationUser user)
    {
        var result = await operation(userManager, user);
        return result.Succeeded
            ? Result.Success()
            : _errorToResultConverter.Convert(result.Errors);
    }
}