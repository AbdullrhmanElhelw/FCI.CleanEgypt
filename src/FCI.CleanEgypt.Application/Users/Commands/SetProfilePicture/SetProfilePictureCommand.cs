using FCI.CleanEgypt.Contracts.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Users.Commands.SetProfilePicture;

public sealed record SetProfilePictureCommand(
    Guid UserId,
    IFormFile Picture) : ICommand;