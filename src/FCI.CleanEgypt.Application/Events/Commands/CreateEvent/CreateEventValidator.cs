using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Events.Commands.CreateEvent;

public class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithError(ValidationErrors.CreateEvent.NameIsRequired);

        RuleFor(x => x.Details)
            .NotEmpty()
            .WithError(ValidationErrors.CreateEvent.DetailsAreRequired);

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithError(ValidationErrors.CreateEvent.DateIsRequired)
            .GreaterThan(DateTime.Today)
            .WithError(ValidationErrors.CreateEvent.DateInTheFuture);
    }
}