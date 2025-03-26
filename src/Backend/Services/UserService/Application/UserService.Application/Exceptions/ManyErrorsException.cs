namespace UserService.Application.Exceptions;

public class ManyErrorsException : Exception
{
    public ManyErrorsException(Dictionary<string, string> errors) : base(string.Join(",", errors))
    {
        Errors = errors;
    }

    public IReadOnlyDictionary<string, string> Errors { get; }
}