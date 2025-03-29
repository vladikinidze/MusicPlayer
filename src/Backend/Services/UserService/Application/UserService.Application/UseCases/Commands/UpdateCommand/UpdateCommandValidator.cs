using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Commands.UpdateCommand;

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(UpdateCommand.UserName)} is required")
            .OverridePropertyName(nameof(UpdateCommand.UserName).ToCamelCase());
    }
}