using FCI.CleanEgypt.Application.Core.Helpers;
using FCI.CleanEgypt.Application.Pins.Commands.DeletePin;
using FCI.CleanEgypt.Application.Pins.Commands.RequestPin;
using FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;
using FCI.CleanEgypt.Application.Pins.Queries.GetPin;
using FCI.CleanEgypt.Application.Pins.Queries.GetUserPins;
using FCI.CleanEgypt.Domain.Enums;
using FCI.CleanEgypt.WebApi.Routes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route(ApiRoutes.Pins.Base)]
[ApiController]
[Authorize(Roles = nameof(AppRoles.User))]
public class PinController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public PinController(ISender sender, UserUtility userUtility)
        : base(sender)
    {
        _userUtility = userUtility;
    }

    [HttpPost(ApiRoutes.Pins.Request)]
    public async Task<IActionResult> RequestPin([FromForm] RequestPinDto pinDto)
    {
        var userId = GetId(_userUtility.GetUserId());
        var requestPinCommand = new RequestPinCommand
            (userId,
             pinDto.TypeOfWaste,
             pinDto.Address,
             pinDto.Date,
             pinDto.Longitude,
             pinDto.Latitude,
             pinDto.Image);

        var result = await _sender.Send(requestPinCommand);

        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Pins.GetAll)]
    public async Task<IActionResult> GetPins(int pageNumber, int pageSize)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var requestPinCommand = new GetUserPinsQuery(userId, pageNumber, pageSize);

        var result = await _sender.Send(requestPinCommand);

        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Pins.Get)]
    public async Task<IActionResult> GetPin(Guid pinId)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var requestPinCommand = new GetPinQuery(userId, pinId);

        var result = await _sender.Send(requestPinCommand);

        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpPut(ApiRoutes.Pins.Update)]
    public async Task<IActionResult> UpdatePin(Guid pinId, [FromForm] UpdatePinDto pinDto)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var requestPinCommand = new UpdatePinCommand
            (userId,
             pinId,
             pinDto.TypeOfWaste,
             pinDto.Address,
             pinDto.Date
             );

        var result = await _sender.Send(requestPinCommand);

        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }

    [HttpDelete(ApiRoutes.Pins.Delete)]
    public async Task<IActionResult> DeletePin(Guid pinId)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var requestPinCommand = new DeletePinCommand(userId, pinId);

        var result = await _sender.Send(requestPinCommand);

        return result.IsSuccess
            ? Ok(result)
            : HandleFailure(result);
    }
}