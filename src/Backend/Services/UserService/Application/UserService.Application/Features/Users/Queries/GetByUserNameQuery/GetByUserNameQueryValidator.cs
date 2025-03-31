using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Queries.GetByUserNameQuery;

public class GetByUserNameQueryValidator : AbstractValidator<User.Queries.GetByUserNameQuery.GetByUserNameQuery>
{
    public GetByUserNameQueryValidator()
    {
        RuleFor(query => query.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(User.Queries.GetByUserNameQuery.GetByUserNameQuery.UserName)} is required")
            .OverridePropertyName(nameof(User.Queries.GetByUserNameQuery.GetByUserNameQuery.UserName).ToCamelCase());
    }
}