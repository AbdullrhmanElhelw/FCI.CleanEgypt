using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Commands.DeleteProfilePicture;

public sealed class DeleteProfilePictureCommandHandler
    : ICommandHandler<DeleteProfilePictureCommand>
{
    private readonly UserManager<User> _userManager;

    public DeleteProfilePictureCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(DeleteProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        var user = User.DeleteProfilePicture(checkUserIsExists);

        var deleteResult = await _userManager.UpdateAsync(user);

        return deleteResult.Succeeded
            ? Result.Ok()
            : Result.Fail(DatabaseErrors.Users.FailedToDeleteProfilePicture);
    }
}