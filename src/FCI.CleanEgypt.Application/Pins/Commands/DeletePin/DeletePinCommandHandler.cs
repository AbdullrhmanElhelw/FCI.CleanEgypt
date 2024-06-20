using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Commands.DeletePin;

public sealed class DeletePinCommandHandler
    : ICommandHandler<DeletePinCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IPinRepository _pinRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePinCommandHandler(UserManager<User> userManager, IPinRepository pinRepository, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _pinRepository = pinRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePinCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists == null)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        var pin = await _pinRepository.GetPinAsync(request.PinId, cancellationToken);

        if (pin is null)
            return Result.Fail(DatabaseErrors.Pins.PinNotFound(request.PinId));

        if (pin.UserId != request.UserId)
            return Result.Fail(DatabaseErrors.Pins.PinIsNotBelongToUser(request.PinId, request.UserId));

        pin = Pin.Delete(pin);

        _pinRepository.Update(pin);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail(DatabaseErrors.DbTransaction.FailedToSaveChanges(pin))
            : Result.Ok("Pin Deleted Successfully");
    }
}