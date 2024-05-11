using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Admins.Commands.CreateAdmin;

public sealed class CreateAdminCommandValidator : AbstractValidator<CreateAdminCommand>
{
    public CreateAdminCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.FirstNameIsRequired);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.LastNameIsRequired);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.EmailIsRequired)
            .EmailAddress()
            .WithError(ValidationErrors.CreateAdmin.IsEmail);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.PasswordIsRequired);

        RuleFor(x => x.City)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.CityIsRequired);

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithError(ValidationErrors.CreateAdmin.StreetIsRequired);
    }
}