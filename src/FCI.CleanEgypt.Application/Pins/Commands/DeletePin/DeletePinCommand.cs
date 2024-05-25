using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Pins.Commands.DeletePin;

public sealed record DeletePinCommand
    (Guid UserId,
    Guid PinId) : ICommand;