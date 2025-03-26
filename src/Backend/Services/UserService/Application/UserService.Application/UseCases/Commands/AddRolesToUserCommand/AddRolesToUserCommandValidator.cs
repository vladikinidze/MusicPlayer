using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommandValidator : AbstractValidator<AddRolesToUserCommand>
{
    public AddRolesToUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(AddRolesToUserCommand.UserId)} is required")
            .OverridePropertyName(nameof(AddRolesToUserCommand.UserId).ToCamelCase());
        
        RuleFor(command => command.Roles)
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage($"{nameof(AddRolesToUserCommand.Roles)} must be unique")
            .OverridePropertyName(nameof(AddRolesToUserCommand.Roles).ToCamelCase());
    }
}