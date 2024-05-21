using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed class UpdatePinCommandHandler
    : ICommandHandler<UpdatePinCommand>
{
    private readonly UserManager<BaseIdentityEntity> _userManager;
    private readonly IPinRepository _pinRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePinCommandHandler(UserManager<BaseIdentityEntity> userManager,
        IPinRepository pinRepository,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _pinRepository = pinRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePinCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
        {
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));
        }

        var pin = await _pinRepository.GetPin(request.PinId);

        if (pin is null)
        {
            return Result.Fail(DatabaseErrors.Pins.PinNotFound(request.PinId));
        }

        var pinToUpdate = Pin.Update(
            pin,
            request.City,
            request.Street,
            request.Description);

        _pinRepository.Update(pinToUpdate);

        return await _unitOfWork.SaveChangesAsync() == 0 ?
            Result.Fail(DatabaseErrors.Pins.FailedToUpdatePin(request.PinId)) :
            Result.Ok("Pin Updated Successfully");
    }
}