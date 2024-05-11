using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FluentValidation;
using MediatR;

namespace FCI.CleanEgypt.Contracts.CQRS.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        var errors = validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => new Error(error.ErrorMessage))
            .Distinct()
            .ToArray();


        if (errors.Length != 0)
            return CreateValidationResult<TResponse>(errors);

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result)) return (ValidationResult.WithErrors(errors) as TResult)!;

        var validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult)).GenericTypeArguments[0]
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, new object[] { errors })!;

        return (TResult)validationResult!;
    }
}