using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommandValidator : AbstractValidator<User.Commands.AddRolesToUserCommand.AddRolesToUserCommand>
{
    public AddRolesToUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.AddRolesToUserCommand.AddRolesToUserCommand.UserId)} is required")
            .OverridePropertyName(nameof(User.Commands.AddRolesToUserCommand.AddRolesToUserCommand.UserId).ToCamelCase());
        
        RuleFor(command => command.Roles)
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage($"{nameof(User.Commands.AddRolesToUserCommand.AddRolesToUserCommand.Roles)} must be unique")
            .OverridePropertyName(nameof(User.Commands.AddRolesToUserCommand.AddRolesToUserCommand.Roles).ToCamelCase());
    }
}