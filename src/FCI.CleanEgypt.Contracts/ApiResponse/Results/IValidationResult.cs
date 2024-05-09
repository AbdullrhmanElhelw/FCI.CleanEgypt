namespace FCI.CleanEgypt.Contracts.ApiResponse.Results;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        nameof(ValidationError));

    Error[] Errors { get; }
}