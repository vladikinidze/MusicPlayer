using UserService.Domain.ValueObjects;

namespace UserService.Application.Common.Converters;

public interface IErrorToDomainErrorConverter<TError>
{
    IEnumerable<Error> Convert(IEnumerable<TError> errors);
}