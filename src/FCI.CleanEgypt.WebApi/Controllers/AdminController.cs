using FCI.CleanEgypt.Application.Admins.Commands.CreateAdmin;
using FCI.CleanEgypt.Application.Admins.Commands.Login;
using FCI.CleanEgypt.WebApi.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route(ApiRoutes.Admin.Base)]
[ApiController]
//[Authorize(Roles = nameof(AppRoles.Admin))]
public class AdminController : ApiBaseController
{
    //private readonly IHttpContextAccessor _httpContextAccessor;

    public AdminController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Admin.Create)]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminCommand adminCommand)
    {
        var result = await _sender.Send(adminCommand);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPost(ApiRoutes.Admin.Login)]
    public async Task<IActionResult> Login([FromBody] AdminLoginCommand loginCommand)
    {
        var result = await _sender.Send(loginCommand);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}