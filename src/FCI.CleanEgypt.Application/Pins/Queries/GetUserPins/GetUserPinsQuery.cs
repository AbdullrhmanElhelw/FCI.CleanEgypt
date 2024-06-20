using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetUserPins;

public sealed record GetUserPinsQuery
    (Guid UserId, int PageNumber, int PageSize) : IQuery<PagedList<PinDto>>;