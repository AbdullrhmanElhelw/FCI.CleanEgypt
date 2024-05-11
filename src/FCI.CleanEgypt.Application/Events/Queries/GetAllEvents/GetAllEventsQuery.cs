using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Events.Queries.GetAllEvents;

public sealed record GetAllEventsQuery(
    int PageNumber,
    int PageSize,
    string SearchTerm)
    : IQuery<PagedList<GetAllEventsResponse>>;