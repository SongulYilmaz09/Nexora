using Nexora.Application.Common.Errors;

namespace Nexora.Application.Common.Results;

public class Result<T> : Result
{
    public T? Value { get; }

    protected Result(T? value, bool isSuccess, Error? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, null);
    }

    public static new Result<T> Failure(Error error)
    {
        return new Result<T>(default, false, error);
    }
}