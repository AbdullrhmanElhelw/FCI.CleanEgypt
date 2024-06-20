using FCI.CleanEgypt.Application.Core.Errors;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Pins.Commands.RequestPin;

public sealed class RequestPinCommandValidator : AbstractValidator<RequestPinCommand>
{
    public RequestPinCommandValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .WithMessage(ValidationErrors.RequestPin.UserIdIsRequired.Message);

        RuleFor(x => x.TypeOfWaste)
            .NotEmpty()
            .WithMessage(ValidationErrors.RequestPin.AddressIsRequired.Message);

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage(ValidationErrors.RequestPin.AddressIsRequired.Message);

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage(ValidationErrors.RequestPin.DateIsRequired.Message);
    }
}