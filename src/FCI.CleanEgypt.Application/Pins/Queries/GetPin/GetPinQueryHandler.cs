using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetPin;

public sealed class GetPinQueryHandler
    : IQueryHandler<GetPinQuery, GetPinResponse>

{
    private readonly IPinRepository _pinRepository;
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public GetPinQueryHandler(IPinRepository pinRepository, UserManager<BaseIdentityEntity> userManager)
    {
        _pinRepository = pinRepository;
        _userManager = userManager;
    }

    public async Task<Result<GetPinResponse>> Handle(GetPinQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
        {
            return Result.Fail<GetPinResponse>(DatabaseErrors.Users.UserIsNotExist(request.UserId));
        }

        var pin = await _pinRepository.GetPin(request.PinId, cancellationToken);

        return pin is null
            ? Result.Fail<GetPinResponse>(DatabaseErrors.Pins.PinNotFound(request.PinId))
            : Result.Ok(new GetPinResponse(pin.Id, pin.City, pin.Street, pin.Description));
    }
}