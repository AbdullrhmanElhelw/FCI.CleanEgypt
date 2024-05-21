using FCI.CleanEgypt.Application.Core.Extensions;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.Authentication;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Users;
using FCI.CleanEgypt.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler
    : ICommandHandler<CreateUserCommand>
{
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public CreateUserCommandHandler(UserManager<BaseIdentityEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager
            .Users
            .Where(u => u.Email == request.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if (checkUserIsExists is not null)
            return Result.Fail<TokenResponse>("User Is Already Exists");

        var requestDateOfBirth = new DateOnly(request.Year, request.Month, request.Day);

        var userToCreate = User.Create(
            request.FirstName,
            request.LastName,
            request.City,
            request.Street,
            requestDateOfBirth,
            request.Email
        );

        var createUserResult = await _userManager.CreateAsync(userToCreate, request.Password);

        if (!createUserResult.Succeeded)
            return Result.Fail(createUserResult.GetErrors());

        var assignRoleResult = await _userManager.AddToRoleAsync(userToCreate, nameof(AppRoles.User));

        return !createUserResult.Succeeded
            ? Result.Fail(assignRoleResult.GetErrors())
            : Result.Ok("User Created Successfully");
    }
}