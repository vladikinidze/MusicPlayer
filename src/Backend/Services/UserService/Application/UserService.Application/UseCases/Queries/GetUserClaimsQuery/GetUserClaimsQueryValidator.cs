using FluentValidation;

namespace UserService.Application.UseCases.Queries.GetUserClaimsQuery;

public class GetUserClaimsQueryValidator : AbstractValidator<GetUserClaimsQuery>
{
    public GetUserClaimsQueryValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}