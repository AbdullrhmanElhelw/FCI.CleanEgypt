using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Events.Queries.GetEventById;

public sealed record GetEventByIdQuery(Guid EventId) : IQuery<GetEventDto>;

public sealed record GetEventDto(
    Guid EventId,
    string Name,
    DateTime Date,
    string Details);