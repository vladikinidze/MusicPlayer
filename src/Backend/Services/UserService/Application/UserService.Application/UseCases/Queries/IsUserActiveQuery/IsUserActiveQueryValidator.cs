using FluentValidation;

namespace UserService.Application.UseCases.Queries.IsUserActiveQuery;

public class IsUserActiveQueryValidator : AbstractValidator<IsUserActiveQuery>
{
    public IsUserActiveQueryValidator()
    {
        RuleFor(query => query.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}