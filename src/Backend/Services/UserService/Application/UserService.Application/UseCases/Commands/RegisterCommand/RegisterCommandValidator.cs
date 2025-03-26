using System.Text.RegularExpressions;
using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Commands.RegisterCommand;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(RegisterCommand.UserName)} is required")
            .MaximumLength(50)
            .WithMessage($"{nameof(RegisterCommand.UserName)} is too long. Maximum length is 50")
            .OverridePropertyName(nameof(RegisterCommand.UserName).ToCamelCase());
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage($"{nameof(RegisterCommand.Email)} is required")
            .EmailAddress()
            .WithMessage("Invalid email format")
            .OverridePropertyName(nameof(RegisterCommand.Email).ToCamelCase());
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage($"{nameof(RegisterCommand.Password)} is required")
            .MinimumLength(8)
            .WithMessage($"{nameof(RegisterCommand.Password)} minimum length is 8")
            .Must(password => Regex.IsMatch(password, @"[!@#$%^&*()_+<>,?!:{}|\]\[""]"))
            .WithMessage($"{nameof(RegisterCommand.Password)} must contain at least one special character")
            .Must(password => Regex.Count(password, @"\d") >= 1)
            .WithMessage($"{nameof(RegisterCommand.Password)} must contain at least one digit")
            .OverridePropertyName(nameof(RegisterCommand.Password).ToCamelCase());

        RuleFor(command => command.ConfirmPassword)
            .NotEmpty()
            .WithMessage($"{nameof(RegisterCommand.ConfirmPassword)} is required")
            .Equal(command => command.Password)
            .WithMessage("Passwords don't match")
            .OverridePropertyName(nameof(RegisterCommand.ConfirmPassword).ToCamelCase());
    }
}