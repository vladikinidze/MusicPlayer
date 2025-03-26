using FluentValidation;

namespace UserService.Application.UseCases.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommandValidator : AbstractValidator<AddRolesToUserCommand>
{
    public AddRolesToUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage("UserId is required");
        
        RuleFor(command => command.Roles)
            .Must(roles => roles.Distinct().Count() == roles.Count)
            .WithMessage("Roles must be unique");
    }
}