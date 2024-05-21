using FCI.CleanEgypt.Application.Core.Extensions;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Admins;
using FCI.CleanEgypt.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Admins.Commands.CreateAdmin;

public sealed class CreateAdminCommandHandler
    : ICommandHandler<CreateAdminCommand>
{
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public CreateAdminCommandHandler(UserManager<BaseIdentityEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var checkAdminIsExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkAdminIsExists is not null)
            return Result.Fail("User is Already Exists");

        var requestDateOfBirth = new DateOnly(request.Year, request.Month, request.Day);

        var adminToCreate = Admin.Create(
            request.FirstName,
            request.LastName,
            request.City,
            request.Street,
            requestDateOfBirth,
            request.Email);

        var createAdminResult = await _userManager.CreateAsync(adminToCreate, request.Password);

        if (!createAdminResult.Succeeded)
            return Result.Fail(createAdminResult.GetErrors());

        var assignRoleResult = await _userManager.AddToRoleAsync(adminToCreate, nameof(AppRoles.Admin));

        return !assignRoleResult.Succeeded
            ? Result.Fail(assignRoleResult.GetErrors())
            : Result.Ok("User has been created Successfully");
    }
}