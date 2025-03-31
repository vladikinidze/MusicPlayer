using Microsoft.AspNetCore.Identity;
using UserService.Application.Common.Converters;
using UserService.Application.Common.Results;
using UserService.Domain.ValueObjects;

namespace UserService.Infrastructure.Identity.Converters;

public class ErrorToResultConverter : IErrorToResultConverter<IdentityError>
{
    public Result Convert(IEnumerable<IdentityError> errors)
    {
        return Result.Failure(errors.Select(error => new Error(error.Code, error.Description)));
    }

    public Result<TData> Convert<TData>(IEnumerable<IdentityError> errors)
    {
        return Result<TData>.Failure(errors.Select(error => new Error(error.Code, error.Description)));
    }
}