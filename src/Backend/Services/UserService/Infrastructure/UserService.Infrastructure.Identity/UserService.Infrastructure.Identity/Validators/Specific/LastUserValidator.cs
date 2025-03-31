using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Admin;
using UserService.Domain.ValueObjects;
using UserService.Infrastructure.Identity.Constants;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Validators.Contexts;

namespace UserService.Infrastructure.Identity.Validators.Specific;

public class LastUserValidator : IValidator<UserRolesValidationContext>
{
    private readonly IAdminService _adminService;

    public LastUserValidator(IAdminService adminService)
    {
        _adminService = adminService;
    }
    
    public async Task<Result> ValidateAsync(UserRolesValidationContext context)
    {
        var isLastAdmin = await _adminService.IsLastAdminAsync(context.User);
        if (isLastAdmin.Value && context.Roles.Contains(RoleConstants.Admin))
        {
            return Result.Failure(new Error(
                nameof(UserRolesValidationContext.Roles), 
                $"Can't remove last \"{RoleConstants.Admin}\""));
        }
        
        return Result.Success();
    }
}