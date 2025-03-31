using UserService.Domain.ValueObjects;

namespace UserService.Application.Common.Results;

public class Result
{
    public Result(bool isSuccess, IEnumerable<Error>? errors)
    {
        IsSuccess = isSuccess;
        Errors = errors?.ToList().AsReadOnly();
    }
    
    public bool IsSuccess { get; }
    public IReadOnlyList<Error>? Errors { get; }
    
    public static Result Success() => new(true, null);
    public static Result Failure(IEnumerable<Error> errors) => new(false, errors);
    public static Result Failure(Error error) => new(false, [error]);
    
    
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(IEnumerable<Error> errors) => Result<T>.Failure(errors);
    public static Result<T> Failure<T>(Error error) => Result<T>.Failure([error]);
}

public class Result<T> : Result
{
    private Result(bool isSuccess, T value, IEnumerable<Error>? errors)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public T? Value { get; }
    
    public static Result<T> Success(T value) => new(true, value, null);
    public new static Result<T> Failure(IEnumerable<Error> errors) => new(false, default!, errors);
}