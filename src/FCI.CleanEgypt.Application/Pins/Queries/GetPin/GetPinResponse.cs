namespace FCI.CleanEgypt.Application.Pins.Queries.GetPin;

public sealed record GetPinResponse(
    Guid PinId,
    string City,
    string Street,
    string Description);