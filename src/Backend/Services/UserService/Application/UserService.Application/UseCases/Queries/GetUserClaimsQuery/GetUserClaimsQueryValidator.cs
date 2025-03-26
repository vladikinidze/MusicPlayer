using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Queries.GetUserClaimsQuery;

public class GetUserClaimsQueryValidator : AbstractValidator<GetUserClaimsQuery>
{
    public GetUserClaimsQueryValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(GetUserClaimsQuery.UserId)} is required")
            .OverridePropertyName(nameof(GetUserClaimsQuery.UserId).ToCamelCase());
    }
}