using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Events.Commands.UpdateEvent;

public sealed record UpdateEventCommand(
    Guid EventId,
    string Name,
    DateTime Date,
    string Details) : ICommand;