using FluentValidation;

namespace UserService.Application.UseCases.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQueryValidator : AbstractValidator<GetUsersByIdsQuery>
{
    public GetUsersByIdsQueryValidator()
    {
        RuleFor(query => query.Ids)
            .NotEmpty().WithMessage("At least one user Id is required")
            .Must(ids => ids.Distinct().Count() == ids.Count)
            .WithMessage("User IDs must be unique");
    }
}