using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.UseCases.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQueryValidator : AbstractValidator<GetUsersByIdsQuery>
{
    public GetUsersByIdsQueryValidator()
    {
        RuleFor(query => query.Ids)
            .NotEmpty().WithMessage("At least one user Id is required")
            .Must(ids => ids.Distinct().Count() == ids.Count)
            .WithMessage($"{nameof(GetUsersByIdsQuery.Ids)} must be unique")
            .OverridePropertyName(nameof(GetUsersByIdsQuery.Ids).ToCamelCase());
    }
}