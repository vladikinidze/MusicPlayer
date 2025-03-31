using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Queries.IsUserActiveQuery;

public class IsUserActiveQueryValidator : AbstractValidator<User.Queries.IsUserActiveQuery.IsUserActiveQuery>
{
    public IsUserActiveQueryValidator()
    {
        RuleFor(query => query.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(User.Queries.IsUserActiveQuery.IsUserActiveQuery.UserId)} is required")
            .OverridePropertyName(nameof(User.Queries.IsUserActiveQuery.IsUserActiveQuery.UserId).ToCamelCase());
    }
}