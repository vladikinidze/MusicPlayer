using UserService.Domain.ValueObjects;

namespace UserService.Domain.Exceptions;

public class AggregateErrorException : Exception
{
    public AggregateErrorException(List<Error> errors) 
        : base(string.Join(",", errors.Select(error => error.Description)))
    {
        Errors = errors.AsReadOnly();
    }   
    
    public IReadOnlyList<Error> Errors { get; }
}