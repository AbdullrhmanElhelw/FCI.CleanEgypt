using FCI.CleanEgypt.Application.Pins.Commands.CreatePin;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CheckPinIsExistsFilter : IAsyncActionFilter
{
    private readonly IPinRepository _pinRepository;

    public CheckPinIsExistsFilter(IPinRepository pinRepository)
    {
        _pinRepository = pinRepository;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("createPinDto", out var value))
        {
            if (value is CreatePinDto createPinDto)
            {
                var existingPins = await _pinRepository.FindPinAsync(createPinDto.City, createPinDto.Street);

                if (existingPins is not null)
                {
                    context.Result = new BadRequestObjectResult("Pin already exists");
                    return;
                }
            }
        }
        await next();
    }
}