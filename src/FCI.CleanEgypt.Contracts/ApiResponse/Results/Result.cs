namespace FCI.CleanEgypt.Contracts.ApiResponse.Results;

public class Result
{
    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Error? Error { get; }

    public static Result Ok()
    {
        return new Result(true, null);
    }

    public static Result Fail(Error error)
    {
        return new Result(false, error);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> Fail<T>(Error error)
    {
        return new Result<T>(false, default!, error);
    }
}