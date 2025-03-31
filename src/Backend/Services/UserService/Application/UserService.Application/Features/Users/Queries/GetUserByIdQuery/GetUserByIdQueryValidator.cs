using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Queries.GetUserByIdQuery;

public class GetUserByIdQueryValidator : AbstractValidator<User.Queries.GetUserByIdQuery.GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(query => query.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(User.Queries.GetUserByIdQuery.GetUserByIdQuery.UserId)} is required")
            .OverridePropertyName(nameof(User.Queries.GetUserByIdQuery.GetUserByIdQuery.UserId).ToCamelCase());
    }
}