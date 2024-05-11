using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Events;

namespace FCI.CleanEgypt.Application.Events.Queries.GetAllEvents;

public sealed class GetAllEventsQueryHandler(IEventRepository eventRepository)
    : IQueryHandler<GetAllEventsQuery, PagedList<GetAllEventsResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<Result<PagedList<GetAllEventsResponse>>> Handle(GetAllEventsQuery request,
        CancellationToken cancellationToken)
    {
        var count = await _eventRepository.EventCountAsync();
        if (count == 0)
            return new PagedList<GetAllEventsResponse>([], 0, 0, 0);

        var events = _eventRepository.GetAllEventsAsync(request.PageSize, request.PageNumber, request.SearchTerm)
            .Result.Select(x => new GetAllEventsResponse(
                x.Id,
                x.Name,
                x.Date,
                x.Detalis));

        return Result.Ok(new PagedList<GetAllEventsResponse>(events, count, request.PageNumber, request.PageSize));
    }
}