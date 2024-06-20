using FCI.CleanEgypt.Application.Core.Errors;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed class UpdatePinCommandValidator : AbstractValidator<UpdatePinCommand>
{
    public UpdatePinCommandValidator()
    {
        RuleFor(x => x.UserId)
          .NotEmpty()
          .WithMessage(ValidationErrors.UpdatePin.UserIdIsRequired.Message);

        RuleFor(x => x.PinId)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdatePin.PinIdIsRequired.Message);

        RuleFor(x => x.TypeOfWaste)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdatePin.TypeOfWasteIsRequired.Message);

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdatePin.AddressIsRequired.Message);

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdatePin.DateIsRequired.Message);
    }
}