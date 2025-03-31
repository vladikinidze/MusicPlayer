using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Commands.AddRolesCommand;

public class AddRolesCommandValidator : AbstractValidator<User.Commands.AddRolesCommand.AddRolesCommand>
{
    public AddRolesCommandValidator()
    {
        RuleFor(command => command.Roles)
            .NotEmpty()
            .WithMessage("At least one role is required")
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage($"{nameof(User.Commands.AddRolesCommand.AddRolesCommand.Roles)} must be unique")
            .OverridePropertyName(nameof(User.Commands.AddRolesCommand.AddRolesCommand.Roles).ToCamelCase());
    }
}