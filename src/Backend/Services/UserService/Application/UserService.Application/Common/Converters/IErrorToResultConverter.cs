using UserService.Application.Common.Results;

namespace UserService.Application.Common.Converters;

public interface IErrorToResultConverter<TError>
{   
    Result Convert(IEnumerable<TError> errors);
    Result<TData> Convert<TData>(IEnumerable<TError> errors);
}