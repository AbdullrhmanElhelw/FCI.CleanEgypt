using FCI.CleanEgypt.Application.Core.Helpers;
using FCI.CleanEgypt.Application.Pins.Commands.CreatePin;
using FCI.CleanEgypt.Application.Pins.Commands.DeletePin;
using FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;
using FCI.CleanEgypt.Application.Pins.Queries.GetAllPins;
using FCI.CleanEgypt.Application.Pins.Queries.GetPin;
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

    [HttpPost(ApiRoutes.Pins.Create)]
    [ServiceFilter(typeof(CheckPinIsExistsFilter))]
    public async Task<IActionResult> Post([FromForm] CreatePinDto createPinDto)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new CreatePinCommand(
            userId,
            createPinDto.City,
            createPinDto.Street,
            createPinDto.Description,
            createPinDto.Image));

        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Pins.Get)]
    public async Task<IActionResult> Get(Guid pinId)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new GetPinQuery(userId, pinId));

        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpGet(ApiRoutes.Pins.GetAll)]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new GetAllPinsQuery(userId, pageNumber, pageSize));

        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpPut(ApiRoutes.Pins.Update)]
    public async Task<IActionResult> Put(Guid pinId, [FromForm] CreatePinDto command)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new UpdatePinCommand(userId,
            pinId,
            command.City,
            command.Street,
            command.Description));

        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }

    [HttpDelete(ApiRoutes.Pins.Delete)]
    public async Task<IActionResult> Delete(Guid pinId)
    {
        var userId = GetId(_userUtility.GetUserId());

        if (userId == Guid.Empty)
            return Unauthorized();

        var result = await _sender.Send(new DeletePinCommand(userId, pinId));

        return result.IsSuccess ?
            Ok(result) :
            BadRequest(result);
    }
}