using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetAllPins;

public sealed class GetAllPinsQueryHandler
    : IQueryHandler<GetAllPinsQuery, PagedList<GetAllPinsResponse>>
{
    private readonly IPinRepository _pinRepository;
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public GetAllPinsQueryHandler(IPinRepository pinRepository, UserManager<BaseIdentityEntity> userManager)
    {
        _pinRepository = pinRepository;
        _userManager = userManager;
    }

    public async Task<Result<PagedList<GetAllPinsResponse>>> Handle(GetAllPinsQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
        {
            return Result.Fail<PagedList<GetAllPinsResponse>>(DatabaseErrors.Users.UserIsNotExist(request.UserId));
        }

        var pins = await _pinRepository.GetAllPinsAsync(
            request.UserId,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        var totalPins = await _pinRepository.GetPinCountAsync(request.UserId, cancellationToken);

        var pinsResponse = pins.Select(pin => new GetAllPinsResponse(pin.Id,
            pin.City,
            pin.Street,
            pin.Description));

        return Result.Ok(new PagedList<GetAllPinsResponse>(
            pinsResponse,
            totalPins,
            request.PageNumber,
            request.PageSize));
    }
}