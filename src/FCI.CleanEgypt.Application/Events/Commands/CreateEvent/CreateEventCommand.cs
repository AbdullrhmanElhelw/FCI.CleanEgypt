using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Events.Commands.CreateEvent;

public sealed record CreateEventCommand(
    string Name,
    DateTime Date,
    string Details) : ICommand;