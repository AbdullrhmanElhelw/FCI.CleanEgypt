namespace FCI.CleanEgypt.Application.Events.Queries.GetAllEvents;

public sealed record GetAllEventsResponse(
    Guid EventId,
    string Name,
    DateTime Date,
    string Details);