using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetAllPins;

public sealed record GetAllPinsQuery
    (Guid UserId,
    int PageNumber,
    int PageSize) : IQuery<PagedList<GetAllPinsResponse>>;