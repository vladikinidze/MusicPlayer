using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Commands.LoginCommand;

public class LoginCommandValidation : AbstractValidator<User.Commands.LoginCommand.LoginCommand>
{
    public LoginCommandValidation()
    {
        RuleFor(command => command.Login)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.LoginCommand.LoginCommand.Login)} is required")
            .OverridePropertyName(nameof(User.Commands.LoginCommand.LoginCommand.Login).ToCamelCase());
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.LoginCommand.LoginCommand.Password)} is required")
            .OverridePropertyName(nameof(User.Commands.LoginCommand.LoginCommand.Password).ToCamelCase());
    }
}