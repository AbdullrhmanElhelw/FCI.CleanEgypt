using FCI.CleanEgypt.Application.Core.Errors;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Events.Commands.UpdateEvent;

public sealed class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationErrors.UpdateEvent.NameIsRequired.Message);

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage(ValidationErrors.UpdateEvent.DateIsRequired.Message)
            .Must(x => x > DateTime.Now).WithMessage(ValidationErrors.UpdateEvent.DateInTheFuture.Message);

        RuleFor(x => x.Details)
            .NotEmpty().WithMessage(ValidationErrors.UpdateEvent.DetailsAreRequired.Message);
    }
}