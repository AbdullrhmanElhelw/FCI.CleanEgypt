using System.Security.Claims;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.Authentication;
using FCI.CleanEgypt.Contracts.Authentication.Jwt;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Admins.Commands.Login;

public sealed class AdminLoginCommandHandler
    : ICommandHandler<AdminLoginCommand>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public AdminLoginCommandHandler(UserManager<BaseIdentityEntity> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        var checkAdminIsExists = await _userManager.FindByEmailAsync(request.Email);
        if (checkAdminIsExists is null)
            return Result.Fail<TokenResponse>("User is not Exists");

        var checkPasswordIsCorrect = await _userManager.CheckPasswordAsync(checkAdminIsExists, request.Password);
        if (checkPasswordIsCorrect is false)
            return Result.Fail<TokenResponse>("Password is not correct");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, request.Email),
            new(ClaimTypes.NameIdentifier, checkAdminIsExists.Id.ToString()),
            new(ClaimTypes.Role, nameof(AppRoles.Admin))
        };

        var token = _jwtProvider.CreateToken(claims);

        return Result.Ok(new TokenResponse(token));
    }
}