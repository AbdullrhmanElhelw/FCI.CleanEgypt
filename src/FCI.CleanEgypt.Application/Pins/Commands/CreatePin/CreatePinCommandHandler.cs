using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Pins.Commands.CreatePin;

public sealed class CreatePinCommandHandler
    : ICommandHandler<CreatePinCommand>
{
    private readonly UserManager<BaseIdentityEntity> _userManager;
    private readonly IPinRepository _pinRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePinCommandHandler(
        UserManager<BaseIdentityEntity> userManager,
        IPinRepository pinRepository,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _pinRepository = pinRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePinCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString())
            != null;

        if (!checkUserIsExists)
            return Result.Fail(DatabaseErrors.Users.UserIsNotExist(request.UserId));

        Image imageToSave = null!;
        if (request.Image is not null)
        {
            using var memoryStream = new MemoryStream();
            await request.Image.CopyToAsync(memoryStream, cancellationToken);
            var imageBytes = memoryStream.ToArray();
            imageToSave = Image.Create
                (request.Image.FileName, request.Image.ContentType, imageBytes);
        };

        var pin = Pin.Create(
            request.City,
            request.Street,
            request.Description,
            request.UserId,
            imageToSave);

        _pinRepository.Create(pin);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
                ? Result.Fail(DatabaseErrors.DbTransaction.FailedToSaveChanges(pin))
                : Result.Ok();
    }
}