namespace FCI.CleanEgypt.Application.Pins.Queries.GetAllPins;

public sealed record GetAllPinsResponse(
    Guid PinId,
    string City,
    string Street,
    string Description);