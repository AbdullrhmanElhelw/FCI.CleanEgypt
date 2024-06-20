using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Pagination;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetUserPins;

public sealed class GetUserPinsQueryHandler :
    IQueryHandler<GetUserPinsQuery, PagedList<PinDto>>
{
    private readonly UserManager<User> _userManager;

    private readonly IPinRepository _pinRepository;

    public GetUserPinsQueryHandler(UserManager<User> userManager, IPinRepository pinRepository)
    {
        _userManager = userManager;
        _pinRepository = pinRepository;
    }

    public async Task<Result<PagedList<PinDto>>> Handle(GetUserPinsQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists == null)
            return Result.Fail<Result<PagedList<PinDto>>>(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        var pins = await _pinRepository.GetAllPinsAsync(request.UserId, request.PageNumber, request.PageSize, cancellationToken);

        var totalPins = await _pinRepository.GetPinCountAsync(request.UserId, cancellationToken);

        var pinsResponse = pins.Select(x => new PinDto(x.Id, x.TypeOfWaste, x.Address, x.Date)).ToList();

        return Result.Ok(new PagedList<PinDto>(pinsResponse, totalPins, request.PageNumber, request.PageSize));
    }
}