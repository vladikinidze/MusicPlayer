using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Queries.GetUserClaimsQuery;

public class GetUserClaimsQueryValidator : AbstractValidator<User.Queries.GetUserClaimsQuery.GetUserClaimsQuery>
{
    public GetUserClaimsQueryValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(User.Queries.GetUserClaimsQuery.GetUserClaimsQuery.UserId)} is required")
            .OverridePropertyName(nameof(User.Queries.GetUserClaimsQuery.GetUserClaimsQuery.UserId).ToCamelCase());
    }
}