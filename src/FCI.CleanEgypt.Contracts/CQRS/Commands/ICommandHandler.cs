using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using MediatR;

namespace FCI.CleanEgypt.Contracts.CQRS.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}