using UserService.Application.Common.Results;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Constants;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Interfaces.Validators.Services;
using UserService.Infrastructure.Identity.Validators.Contexts;

namespace UserService.Infrastructure.Identity.Validators.Services;

public class UserRoleServiceValidator : IUserRoleServiceValidator
{
    private readonly IValidator<UserRolesValidationContext> _validator;

    public UserRoleServiceValidator(IValidator<UserRolesValidationContext> validator)
    {
        _validator = validator;
    }
    
    public async Task<Result> ValidateAddRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        var context = new UserRolesValidationContext(user, roles, UserRolesOperations.Add);
        return await _validator.ValidateAsync(context);
    }

    public async Task<Result> ValidateRemoveRolesAsync(IApplicationUser user, IEnumerable<string> roles)
    {
        var context = new UserRolesValidationContext(user, roles, UserRolesOperations.Remove);
        return await _validator.ValidateAsync(context);
    }
}