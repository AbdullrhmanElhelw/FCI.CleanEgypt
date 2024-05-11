namespace FCI.CleanEgypt.Application.Events.Commands.UpdateEvent;

public sealed record UpdateEventDto(
    string Name,
    DateTime Date,
    string Details);