using FCI.CleanEgypt.Application.Core.Errors;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdateUser.FirstNameIsRequired.Message);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdateUser.LastNameIsRequired.Message);

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdateUser.CityIsRequired.Message);

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage(ValidationErrors.UpdateUser.StreetIsRequired.Message);

        RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage(ValidationErrors.DateOfBirth.YearIsRequired.Message)
            .LessThan(DateTime.Now.Year)
            .WithMessage(ValidationErrors.DateOfBirth.YearMustBeLessThanCurrentYear);

        RuleFor(x => x.Month)
            .NotEmpty()
            .WithMessage(ValidationErrors.DateOfBirth.MonthIsRequired.Message)
            .LessThan(13)
            .WithMessage(ValidationErrors.DateOfBirth.MonthLessThan13.Message);

        RuleFor(x => x.Day)
            .NotEmpty()
            .WithMessage(ValidationErrors.DateOfBirth.DayIsRequired.Message)
            .LessThan(32)
            .WithMessage(ValidationErrors.DateOfBirth.DayLessThan32);
    }
}