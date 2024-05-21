using FCI.CleanEgypt.Application.Core.Errors;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Pins.Commands.CreatePin;

public sealed class CreatePinCommandValidator : AbstractValidator<CreatePinCommand>
{
    public CreatePinCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ValidationErrors.CreatePin.UserIdIsRequired.Message);

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage(ValidationErrors.CreatePin.CityIsRequired.Message);

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage(ValidationErrors.CreatePin.StreetIsRequired.Message);
    }
}