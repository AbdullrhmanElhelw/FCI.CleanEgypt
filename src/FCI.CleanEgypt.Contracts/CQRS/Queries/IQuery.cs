using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using MediatR;

namespace FCI.CleanEgypt.Contracts.CQRS.Queries;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}