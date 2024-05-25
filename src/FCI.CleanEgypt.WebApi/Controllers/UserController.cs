using FCI.CleanEgypt.Application.Core.Helpers;
using FCI.CleanEgypt.Application.Users.Commands.CreateUser;
using FCI.CleanEgypt.Application.Users.Commands.Login;
using FCI.CleanEgypt.Application.Users.Commands.SetProfilePicture;
using FCI.CleanEgypt.Application.Users.Commands.UpdateUser;
using FCI.CleanEgypt.Application.Users.Queries.GetProfilePicture;
using FCI.CleanEgypt.Application.Users.Queries.GetUser;
using FCI.CleanEgypt.Domain.Enums;
using FCI.CleanEgypt.WebApi.Routes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route(ApiRoutes.Users.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.User))]
public class UserController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public UserController(ISender sender, UserUtility userUtility)
        : base(sender)
    {
        _userUtility = userUtility;
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Users.Register)]
    public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Users.Login)]
    public async Task<IActionResult> Login([FromForm] UserLoginCommand command)
    {
        var result = await _sender.Send(new UserLoginCommand(command.Email, command.Password));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost(ApiRoutes.Users.SetProfilePicture)]
    public async Task<IActionResult> SetProfilePicture(IFormFile file)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new SetProfilePictureCommand(userId, file));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Users.GetProfilePicture)]
    public async Task<IActionResult> GetProfilePicture()
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new GetProfilePictureQuery(userId));
        if (result.Value is null)
            return NotFound();

        var file = File(result.Value.Data, "application/octet-stream", result.Value.FileName);

        return result.IsSuccess ? file : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Users.Get)]
    public async Task<IActionResult> GetUser()
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new GetUserQuery(userId));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut(ApiRoutes.Users.Update)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto command)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new UpdateUserCommand(
            userId,
            command.FirstName,
            command.LastName,
            command.City,
            command.Street,
            command.Year,
            command.Month,
            command.Day));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}