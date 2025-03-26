using FluentValidation;

namespace UserService.Application.UseCases.Commands.AddRolesCommand;

public class AddRolesCommandValidator : AbstractValidator<AddRolesCommand>
{
    public AddRolesCommandValidator()
    {
        RuleFor(command => command.Roles)
            .NotEmpty().WithMessage("At least one role is required")
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage("Roles must be unique");
    }
}