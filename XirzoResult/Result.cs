using System.Data;

namespace XirzoResult;

public class Result<TValue>
{
    private readonly TValue? _value;

    private Result(TValue value)
    {
        IsSuccess = true;
        _value = value;
        Error = Error.None;
    }

    private Result(Error error)
    {
        _value = default;
        Error = error;
        IsSuccess = false;
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(error);
    }

    public bool IsSuccess { get; }
    public TValue Value => IsSuccess
        ? _value!
        : throw new ConstraintException("Value cannot be accessed if result was not successful");
    public Error Error { get; }

    public TReturn Match<TReturn>(Func<TValue, TReturn> success, Func<Error, TReturn> failure)
    {
        if (IsSuccess)
        {
            return success(_value!);
        }

        return failure(Error);
    }
}