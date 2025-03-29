using UserService.Application.ViewModels;

namespace UserService.Application.Exceptions;

public class AggregateErrorException : Exception
{
    public AggregateErrorException(List<ErrorViewModel> errors) 
        : base(string.Join(",", errors.Select(error => error.Description)))
    {
        Errors = errors.AsReadOnly();
    }   
    
    public IReadOnlyList<ErrorViewModel> Errors { get; }
}