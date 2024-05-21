using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Pins.Commands.UpdatePin;

public sealed class UpdatePinCommandValidator : AbstractValidator<UpdatePinCommand>
{
    public UpdatePinCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithError(ValidationErrors.UpdatePin.UserIdIsRequired);

        RuleFor(x => x.PinId)
            .NotEmpty()
            .WithError(ValidationErrors.UpdatePin.PinIdIsRequired);

        RuleFor(x => x.City)
            .NotEmpty()
            .WithError(ValidationErrors.UpdatePin.CityIsRequired)
            .MaximumLength(50)
            .WithError(ValidationErrors.UpdatePin.CityMaxLength);

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithError(ValidationErrors.UpdatePin.StreetIsRequired)
            .MaximumLength(50)
            .WithError(ValidationErrors.UpdatePin.StreetMaxLength);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithError(ValidationErrors.UpdatePin.DescriptionIsRequired)
            .MaximumLength(500);
    }
}