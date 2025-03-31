using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Results;
using UserService.Domain.ValueObjects;
using UserService.Infrastructure.Identity.Constants;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Interfaces.Validators;
using UserService.Infrastructure.Identity.Models;
using UserService.Infrastructure.Identity.Validators.Contexts;

namespace UserService.Infrastructure.Identity.Validators.Specific;

public class DuplicateUserRolesValidator : IValidator<UserRolesValidationContext>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserCaster _userCaster;

    public DuplicateUserRolesValidator(
        UserManager<ApplicationUser> userManager,
        IUserCaster userCaster)
    {
        _userManager = userManager;
        _userCaster = userCaster;
    }
    
    public async Task<Result> ValidateAsync(UserRolesValidationContext context)
    {
        if (context.OperationType != UserRolesOperations.Add)
        {
            return Result.Success();
        }
        var addRoles = context.Roles.ToList();
        var applicationUser = _userCaster.CastToApplicationUser(context.User);
        var userRoles = await _userManager.GetRolesAsync(applicationUser);
        var duplicateRoles = GetDuplicateRoles(userRoles, addRoles).ToList();
        
        return duplicateRoles.Count != 0
            ? Result.Failure(CreateDuplicateRoleErrors(duplicateRoles))
            : Result.Success();
    }
    
    private static IEnumerable<string> GetDuplicateRoles(
        IEnumerable<string> existingRoles, 
        IEnumerable<string> newRoles)
    {
        var existingSet = new HashSet<string>(existingRoles, StringComparer.OrdinalIgnoreCase);
        return newRoles.Where(role => existingSet.Contains(role));
    }
    
    private static List<Error> CreateDuplicateRoleErrors(IEnumerable<string> duplicateRoles)
    {
        return duplicateRoles
            .Select(role => new Error(role, $"Role '{role}' already assigned"))
            .ToList();
    }
}