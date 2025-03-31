using UserService.Application.Common.Results;
using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Constants;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Interfaces.Validators.Services;
using UserService.Infrastructure.Identity.Validators.Contexts;

namespace UserService.Infrastructure.Identity.Validators.Services;

public class UserServiceValidator : IUserServiceValidator
{
    private readonly IValidator<UserValidationContext> _validator;

    public UserServiceValidator(IValidator<UserValidationContext> validator)
    {
        _validator = validator;
    }
    
    public async Task<Result> ValidateCreationAsync(IApplicationUser user)
    {
        return await InvokeValidator(user, UserOperations.Add);
    }

    public async Task<Result> ValidateUpdateAsync(IApplicationUser user)
    {
        return await InvokeValidator(user, UserOperations.Update);
    }

    public async Task<Result> ValidateRemoveAsync(IApplicationUser user)
    {
        return await InvokeValidator(user, UserOperations.Remove);
    }

    private async Task<Result> InvokeValidator(IApplicationUser user, string operationType)
    {
        var context = new UserValidationContext(user, operationType);
        return await _validator.ValidateAsync(context);
    }
}