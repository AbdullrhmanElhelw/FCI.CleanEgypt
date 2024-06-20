using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed record UpdatePinCommand
    (Guid UserId,
    Guid PinId,
    string TypeOfWaste,
    string Address,
    string Date) : ICommand;