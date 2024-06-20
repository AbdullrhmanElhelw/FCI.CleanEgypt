using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateProfilePicture;

public sealed class UpdateProfilePictureCommandHandler
    : ICommandHandler<UpdateProfilePictureCommand>
{
    private readonly UserManager<User> _userManager;

    public UpdateProfilePictureCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExist = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (checkUserIsExist is null)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        using var memoryStream = new MemoryStream();
        await request.Picture.CopyToAsync(memoryStream, cancellationToken);

        var image = Image.Create(request.Picture.FileName,
                                 request.Picture.ContentType,
                                 memoryStream.ToArray());

        var user = User.UpdateProfilePicture(checkUserIsExist, image);

        var updateResult = await _userManager.UpdateAsync(user);

        return updateResult.Succeeded
            ? Result.Ok("Profile picture updated successfully.")
            : Result.Fail(DatabaseErrors.Users.FailedToUpdateProfilePicture);
    }
}