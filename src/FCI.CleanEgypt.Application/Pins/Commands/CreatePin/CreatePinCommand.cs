using FCI.CleanEgypt.Contracts.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Pins.Commands.CreatePin;

public sealed record CreatePinCommand(
    Guid UserId,
    string City,
    string Street,
    string Description,
    IFormFile? Image = null) : ICommand;