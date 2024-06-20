using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Pins.Commands.RequestPin;

public sealed record RequestPinDto
    (
    string TypeOfWaste,
    string Address,
    string Date,
    double? Longitude,
    double? Latitude,
    IFormFile? Image);