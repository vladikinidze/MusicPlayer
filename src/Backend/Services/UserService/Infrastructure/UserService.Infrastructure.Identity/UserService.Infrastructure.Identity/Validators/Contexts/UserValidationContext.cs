using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces.Validators;

namespace UserService.Infrastructure.Identity.Validators.Contexts;

public record UserValidationContext(
    IApplicationUser User, 
    string OperationType) 
    : IValidationContext;