using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetPin;

public sealed class GetPinQueryHandler
    : IQueryHandler<GetPinQuery, PinDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IPinRepository _pinRepository;

    public GetPinQueryHandler(UserManager<User> userManager, IPinRepository pinRepository)
    {
        _userManager = userManager;
        _pinRepository = pinRepository;
    }

    public async Task<Result<PinDto>> Handle(GetPinQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
            return Result.Fail<PinDto>(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        var pin = await _pinRepository.GetPinAsync(request.PinId);

        if (pin is null)
            return Result.Fail<PinDto>(DatabaseErrors.Pins.PinNotFound(request.PinId));

        if (pin.UserId != request.UserId)
            return Result.Fail<PinDto>(DatabaseErrors.Pins.PinIsNotBelongToUser(request.PinId, request.UserId));

        return Result.Ok(new PinDto(pin.Id, pin.TypeOfWaste, pin.Address, pin.Date));
    }
}