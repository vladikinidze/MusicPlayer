using System.Text.RegularExpressions;
using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Commands.RegisterCommand;

public class RegisterCommandValidator : AbstractValidator<User.Commands.RegisterCommand.RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.UserName)} is required")
            .MaximumLength(50)
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.UserName)} is too long. Maximum length is 50")
            .OverridePropertyName(nameof(User.Commands.RegisterCommand.RegisterCommand.UserName).ToCamelCase());
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.Email)} is required")
            .EmailAddress()
            .WithMessage("Invalid email format")
            .OverridePropertyName(nameof(User.Commands.RegisterCommand.RegisterCommand.Email).ToCamelCase());
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.Password)} is required")
            .MinimumLength(8)
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.Password)} minimum length is 8")
            .Must(password => Regex.IsMatch(password, @"[!@#$%^&*()_+<>,?!:{}|\]\[""]"))
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.Password)} must contain at least one special character")
            .Must(password => Regex.Count(password, @"\d") >= 1)
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.Password)} must contain at least one digit")
            .OverridePropertyName(nameof(User.Commands.RegisterCommand.RegisterCommand.Password).ToCamelCase());

        RuleFor(command => command.ConfirmPassword)
            .NotEmpty()
            .WithMessage($"{nameof(User.Commands.RegisterCommand.RegisterCommand.ConfirmPassword)} is required")
            .Equal(command => command.Password)
            .WithMessage("Passwords don't match")
            .OverridePropertyName(nameof(User.Commands.RegisterCommand.RegisterCommand.ConfirmPassword).ToCamelCase());
    }
}