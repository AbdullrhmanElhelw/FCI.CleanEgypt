using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Users.Commands.Login;

public sealed class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithError(ValidationErrors.Login.EmailIsRequired)
            .EmailAddress()
            .WithError(ValidationErrors.Login.IsEmail);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithError(ValidationErrors.Login.PasswordIsRequired);
    }
}