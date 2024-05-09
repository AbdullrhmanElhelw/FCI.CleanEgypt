using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CreateUserCommandValidator" /> class.
    /// </summary>
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.FirstNameIsRequired);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.LastNameIsRequired);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.EmailIsRequired)
            .EmailAddress()
            .WithError(ValidationErrors.CreateUser.IsEmail);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.PasswordIsRequired);

        RuleFor(x => x.City)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.CityIsRequired);

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithError(ValidationErrors.CreateUser.StreetIsRequired);
    }
}