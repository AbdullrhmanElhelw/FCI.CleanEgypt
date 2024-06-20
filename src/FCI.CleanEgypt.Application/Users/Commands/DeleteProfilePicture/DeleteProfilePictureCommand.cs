using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Users.Commands.DeleteProfilePicture;

public sealed record DeleteProfilePictureCommand
    (Guid UserId) : ICommand;