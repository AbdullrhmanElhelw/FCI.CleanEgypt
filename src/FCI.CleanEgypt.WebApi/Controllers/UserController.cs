using FCI.CleanEgypt.Application.Users.Commands.CreateUser;
using FCI.CleanEgypt.Application.Users.Commands.Login;
using FCI.CleanEgypt.Application.Users.Commands.SetProfilePicture;
using FCI.CleanEgypt.WebApi.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route(ApiRoutes.Users.Base)]
[ApiController]
public class UserController : ApiBaseController
{
    public UserController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Users.Register)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost(ApiRoutes.Users.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
    
    [HttpPost("set-profile-picture/{userId:guid}")]
    public async Task<IActionResult> SetProfilePicture(Guid userId, IFormFile file)
    {
        var command = new SetProfilePictureCommand(userId, file);
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
    
}