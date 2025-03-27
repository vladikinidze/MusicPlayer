using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Queries.GetUserByIdQuery;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(query => query.UserId)
            .NotEmpty()
            .WithMessage($"{nameof(GetUserByIdQuery.UserId)} is required")
            .OverridePropertyName(nameof(GetUserByIdQuery.UserId).ToCamelCase());
    }
}