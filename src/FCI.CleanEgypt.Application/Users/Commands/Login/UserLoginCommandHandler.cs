using System.Security.Claims;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.Authentication;
using FCI.CleanEgypt.Contracts.Authentication.Jwt;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Commands.Login;

public sealed class UserLoginCommandHandler
    : ICommandHandler<UserLoginCommand, TokenResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public UserLoginCommandHandler(UserManager<BaseIdentityEntity> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<TokenResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkUserIsExists is null)
            return Result.Fail<TokenResponse>("User is not exists");

        var checkPassword = await _userManager.CheckPasswordAsync(checkUserIsExists, request.Password);

        if (!checkPassword)
            return Result.Fail<TokenResponse>("Password is not Correct");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, request.Email),
            new(ClaimTypes.NameIdentifier, checkUserIsExists.Id.ToString()),
            new(ClaimTypes.Role, nameof(AppRoles.User))
        };

        var token = _jwtProvider.CreateToken(claims);

        return Result.Ok(new TokenResponse(token));
    }
}