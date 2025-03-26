using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Commands.AddRolesCommand;

public class AddRolesCommandValidator : AbstractValidator<AddRolesCommand>
{
    public AddRolesCommandValidator()
    {
        RuleFor(command => command.Roles)
            .NotEmpty()
            .WithMessage("At least one role is required")
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage($"{nameof(AddRolesCommand.Roles)} must be unique")
            .OverridePropertyName(nameof(AddRolesCommand.Roles).ToCamelCase());
    }
}