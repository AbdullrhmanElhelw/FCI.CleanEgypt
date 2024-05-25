namespace FCI.CleanEgypt.Contracts.ApiResponse.Results;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(bool isSuccess, TValue value, Error? error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value =>
        _value!;

    public static implicit operator TValue(Result<TValue> result)
    {
        return result.Value;
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return Create(value);
    }

    public static Result<TValue> Create(TValue value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        return new Result<TValue>(true, value, Error.None);
    }
}