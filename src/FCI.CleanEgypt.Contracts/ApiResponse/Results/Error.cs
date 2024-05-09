namespace FCI.CleanEgypt.Contracts.ApiResponse.Results;

public sealed record Error(string Message)
{
    public static readonly Error None = new(string.Empty);
    public string Message { get; } = Message;

    public static implicit operator Error(string message)
    {
        return new Error(message);
    }

    public static implicit operator string(Error error)
    {
        return error.Message;
    }
}