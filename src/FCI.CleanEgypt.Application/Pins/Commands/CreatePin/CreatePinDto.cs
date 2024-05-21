using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Pins.Commands.CreatePin;

public sealed record CreatePinDto(
    string City,
    string Street,
    string Description,
    IFormFile Image = null!);