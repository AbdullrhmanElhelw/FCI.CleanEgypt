namespace FCI.CleanEgypt.Application.Pins.Queries;

public sealed record PinDto
    (Guid Id,
    string TypeOfWaste,
    string Address,
    string Date);