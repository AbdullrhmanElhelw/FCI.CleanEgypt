using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Commands.DeletePin;

public sealed class DeletePinCommandHandler
    : ICommandHandler<DeletePinCommand>
{
    private readonly IPinRepository _pinRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<BaseIdentityEntity> _userManager;

    public DeletePinCommandHandler(IPinRepository pinRepository, IUnitOfWork unitOfWork, UserManager<BaseIdentityEntity> userManager)
    {
        _pinRepository = pinRepository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<Result> Handle(DeletePinCommand request, CancellationToken cancellationToken)
    {
        var findUser = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (findUser is null)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        var findPin = await _pinRepository.GetPin(request.PinId, cancellationToken);

        if (findPin is null)
            return Result.Fail("Pin not found");

        await _pinRepository.DeletePin(request.PinId, cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail(DatabaseErrors.DbTransaction.FaildToDelete(findPin))
            : Result.Ok("Pin Deleted Successfully");
    }
}