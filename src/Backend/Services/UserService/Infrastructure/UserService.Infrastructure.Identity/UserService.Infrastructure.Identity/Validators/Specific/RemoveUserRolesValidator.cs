using UserService.Application.Common.Results;
using UserService.Domain.ValueObjects;
using UserService.Infrastructure.Identity.Constants;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Validators.Contexts;

namespace UserService.Infrastructure.Identity.Validators.Specific;

public class RemoveUserRolesValidator : IValidator<UserRolesValidationContext>
{
    public async Task<Result> ValidateAsync(UserRolesValidationContext context)
    {
        var removeRoles = context.Roles.ToList();
        if (!removeRoles.Contains(RoleConstants.User))
        {
            return Result.Failure(new Error(
                nameof(UserRolesValidationContext.Roles), 
                $"Can't remove \"{RoleConstants.User}\" roles"));
        }
        return Result.Success();
    }
}