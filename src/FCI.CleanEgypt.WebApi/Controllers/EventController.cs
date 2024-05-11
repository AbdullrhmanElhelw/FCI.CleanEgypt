using System.Text.Json;
using FCI.CleanEgypt.Application.Events.Commands.CreateEvent;
using FCI.CleanEgypt.Application.Events.Commands.UpdateEvent;
using FCI.CleanEgypt.Application.Events.Queries.GetAllEvents;
using FCI.CleanEgypt.Application.Events.Queries.GetEventById;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.WebApi.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCI.CleanEgypt.WebApi.Controllers;

[Route(ApiRoutes.Events.Base)]
[ApiController]
public class EventController : ApiBaseController
{
    public EventController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Events.Create)]
    public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Events.GetById)]
    public async Task<IActionResult> GetById(Guid eventId)
    {
        var result = await _sender.Send(new GetEventByIdQuery(eventId));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Events.GetAll)]
    public async Task<IActionResult> Search(int pageNumber, int pageSize, string searchTerm = null!)
    {
        var result = await _sender.Send(new GetAllEventsQuery(pageNumber, pageSize, searchTerm));
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(result.Value.MetaData));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }

    [HttpPut(ApiRoutes.Events.Update)]
    public async Task<IActionResult> Update(Guid eventId, [FromBody] UpdateEventDto command)
    {
        var result = await _sender.Send(new UpdateEventCommand(eventId,command.Name, command.Date, command.Details));
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}