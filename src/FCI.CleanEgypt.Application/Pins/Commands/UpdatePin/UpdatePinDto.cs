namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed record UpdatePinDto
    (
    string TypeOfWaste,
    string Address,
    string Date);