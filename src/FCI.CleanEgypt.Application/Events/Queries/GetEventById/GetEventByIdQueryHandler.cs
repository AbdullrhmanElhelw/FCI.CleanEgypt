using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Events;

namespace FCI.CleanEgypt.Application.Events.Queries.GetEventById;

public sealed class GetEventByIdQueryHandler
    : IQueryHandler<GetEventByIdQuery, GetEventDto>
{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<GetEventDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var findEventIsExists = await _eventRepository.FindByIdAsync(request.EventId, cancellationToken);
        if (findEventIsExists is null)
            return Result.Fail<GetEventDto>("Event is not Exists");

        var eventToGet = new GetEventDto(
            findEventIsExists.Id,
            findEventIsExists.Name,
            findEventIsExists.Date,
            findEventIsExists.Detalis);

        return Result.Ok(eventToGet);
    }
}