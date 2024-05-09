using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using MediatR;

namespace FCI.CleanEgypt.Contracts.CQRS.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}