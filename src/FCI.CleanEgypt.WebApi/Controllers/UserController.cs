using FCI.CleanEgypt.Application.Users.Commands.CreateUser;
using FCI.CleanEgypt.Application.Users.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ApiBaseController
{
    public UserController(ISender sender) : base(sender)
    {
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}