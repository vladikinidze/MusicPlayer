using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Queries.GetByUserNameQuery;

public class GetByUserNameQueryValidator : AbstractValidator<GetByUserNameQuery>
{
    public GetByUserNameQueryValidator()
    {
        RuleFor(query => query.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(GetByUserNameQuery.UserName)} is required")
            .OverridePropertyName(nameof(GetByUserNameQuery.UserName).ToCamelCase());
    }
}