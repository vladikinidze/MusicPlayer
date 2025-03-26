using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Commands.LoginCommand;

public class LoginCommandValidation : AbstractValidator<LoginCommand>
{
    public LoginCommandValidation()
    {
        RuleFor(command => command.Login)
            .NotEmpty()
            .WithMessage($"{nameof(LoginCommand.Login)} is required")
            .OverridePropertyName(nameof(LoginCommand.Login).ToCamelCase());
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage($"{nameof(LoginCommand.Password)} is required")
            .OverridePropertyName(nameof(LoginCommand.Password).ToCamelCase());
    }
}