using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Converters;
using UserService.Domain.ValueObjects;

namespace UserService.Infrastructure.Identity.Converters;

public class ErrorToDomainErrorConverter : IErrorToDomainErrorConverter<IdentityError>
{
    public IEnumerable<Error> Convert(IEnumerable<IdentityError> errors)
    {
        return errors.Select(error => new Error(error.Code, error.Description));
    }
}