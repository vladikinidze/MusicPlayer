using System.Text.RegularExpressions;
using FluentValidation;

namespace UserService.Application.UseCases.Commands.RegisterCommand;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty().WithMessage("UserName is required")
            .MaximumLength(50).WithMessage("Name is too long. Maximum length is 50");
        
        RuleFor(command => command.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        
        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password minimum length is 8")
            .Must(password => Regex.IsMatch(password, @"[!@#$%^&*()_+<>,?!:{}|\]\[""]"))
            .WithMessage("Password must contain at least one special character")
            .Must(password => Regex.Count(password, @"\d") >= 1)
            .WithMessage("Password must contain at least one digit");

        RuleFor(command => command.ConfirmPassword)
            .NotEmpty().WithMessage("ConfirmPassword is required")
            .Equal(command => command.Password).WithMessage("Passwords don't match");
    }
}