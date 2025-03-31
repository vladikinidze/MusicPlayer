using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Commands.UpdateCommand;

public class UpdateCommandValidator : AbstractValidator<User.Commands.UpdateCommand.UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.UpdateCommand.UpdateCommand.UserName)} is required")
            .OverridePropertyName(nameof(User.Commands.UpdateCommand.UpdateCommand.UserName).ToCamelCase());
    }
}