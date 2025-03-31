using UserService.Application.Common.Results;

namespace UserService.Infrastructure.Identity.Interfaces.Validators;

public interface IValidator<TContext>
{
    Task<Result> ValidateAsync(TContext context);
}