using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces.Validators;

namespace UserService.Infrastructure.Identity.Validators.Contexts;

public record UserRolesValidationContext(
    IApplicationUser User, 
    IEnumerable<string> Roles, 
    string OperationType) 
    : IValidationContext;