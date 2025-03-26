using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Queries.IsUserActiveQuery;

public class IsUserActiveQueryValidator : AbstractValidator<IsUserActiveQuery>
{
    public IsUserActiveQueryValidator()
    {
        RuleFor(query => query.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(IsUserActiveQuery.UserId)} is required")
            .OverridePropertyName(nameof(IsUserActiveQuery.UserId).ToCamelCase());
    }
}