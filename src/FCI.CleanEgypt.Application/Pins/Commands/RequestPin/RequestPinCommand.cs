using FCI.CleanEgypt.Contracts.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Pins.Commands.RequestPin;

public sealed record RequestPinCommand
    (
     Guid UserId,
     string TypeOfWaste,
     string Address,
     string Date,
     double? Longitude = null,
     double? Latitude = null,
     IFormFile? Image = null) : ICommand;