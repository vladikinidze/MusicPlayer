using FluentValidation;
using UserService.Application.Extensions;

namespace UserService.Application.User.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQueryValidator : AbstractValidator<User.Queries.GetUsersByIdsQuery.GetUsersByIdsQuery>
{
    public GetUsersByIdsQueryValidator()
    {
        RuleFor(query => query.Ids)
            .NotEmpty().WithMessage("At least one user Id is required")
            .Must(ids => ids.Distinct().Count() == ids.Count)
            .WithMessage($"{nameof(User.Queries.GetUsersByIdsQuery.GetUsersByIdsQuery.Ids)} must be unique")
            .OverridePropertyName(nameof(User.Queries.GetUsersByIdsQuery.GetUsersByIdsQuery.Ids).ToCamelCase());
    }
}