using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using MediatR;

namespace FCI.CleanEgypt.Contracts.CQRS.Commands;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}