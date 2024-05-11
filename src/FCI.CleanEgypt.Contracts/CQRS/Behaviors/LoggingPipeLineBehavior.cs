using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FCI.CleanEgypt.Contracts.CQRS.Behaviors;

public class LoggingPipeLineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipeLineBehavior(ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting Request{@RequestName},{@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        var result = await next();

        if (!result.IsSuccess)
            _logger.LogError(
                "Request Failure {@RequestName},{@Error} {@DateTimeUtc}",
                typeof(TRequest).Name,
                result.Error?.Message,
                DateTime.UtcNow);

        _logger.LogInformation(
            "Completed Request{@RequestName},{@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);
        return result;
    }
}