using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler
    : ICommandHandler<UpdateUserCommand>
{
    private readonly UserManager<User> _userManager;

    public UpdateUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.Id.ToString());

        if (checkUserIsExists is null)
            return Result.Fail("User not found");

        var dateOfBirth = new DateOnly(request.Year, request.Month, request.Day);

        var userToUpdate = User.Update(
            checkUserIsExists,
            request.FirstName,
            request.LastName,
            request.City,
            request.Street,
            dateOfBirth);

        var result = await _userManager.UpdateAsync(userToUpdate);

        return result.Succeeded ?
            Result.Ok("User Updated Successfully") :
            Result.Fail(DatabaseErrors.Users.FailedToUpdateUser);
    }
}