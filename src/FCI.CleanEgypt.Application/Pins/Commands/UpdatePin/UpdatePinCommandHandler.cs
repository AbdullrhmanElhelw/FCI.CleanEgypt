using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed class UpdatePinCommandHandler
    : ICommandHandler<UpdatePinCommand>
{
    private readonly UserManager<User> _userManager;

    private readonly IPinRepository _pinRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdatePinCommandHandler(UserManager<User> userManager, IPinRepository pinRepository, IUnitOfWork unitOfWork)
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

        var pin = await _pinRepository.GetPinAsync(request.PinId);

        if (pin is null)
        {
            return Result.Fail(DatabaseErrors.Pins.PinNotFound(request.PinId));
        }

        var updatedPin = Pin.UpdatePin(pin, request.TypeOfWaste, request.Address, request.Date);

        _pinRepository.Update(updatedPin);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail(DatabaseErrors.Pins.FailedToUpdatePin(request.PinId))
            : Result.Ok("Pin Updated Successfully!");
    }
}