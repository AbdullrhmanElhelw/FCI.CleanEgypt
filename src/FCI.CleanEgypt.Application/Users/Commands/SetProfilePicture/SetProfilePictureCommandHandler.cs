using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Commands.SetProfilePicture;

public sealed class SetProfilePictureCommandHandler : ICommandHandler<SetProfilePictureCommand>
{
    private readonly UserManager<User> _userManager;

    public SetProfilePictureCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(SetProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var findUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (findUserIsExists is null)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        using var memoryStream = new MemoryStream();
        await request.Picture.CopyToAsync(memoryStream, cancellationToken);

        var image = Image.Create(request.Picture.FileName,
                                 request.Picture.ContentType,
                                 memoryStream.ToArray());

        var user = User.SetProfilePicture(findUserIsExists, image);

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded
            ? Result.Ok("Profile picture updated successfully.")
            : Result.Fail(DatabaseErrors.Users.FailedToUpdateProfilePicture);
    }
}