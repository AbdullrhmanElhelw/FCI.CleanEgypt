using FCI.CleanEgypt.Contracts.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateProfilePicture;

public sealed record UpdateProfilePictureCommand
    (Guid UserId, IFormFile Picture) : ICommand;