using FCI.CleanEgypt.Contracts.ApiResponse.Results;

namespace FCI.CleanEgypt.Application.Core.Errors;

internal static class ValidationErrors
{
    internal static class Login
    {
        internal static Error EmailIsRequired => new("The email is required.");

        internal static Error PasswordIsRequired => new("The password is required.");
    }

    internal static class ChangePassword
    {
        internal static Error UserIdIsRequired => new("The user identifier is required.");

        internal static Error PasswordIsRequired => new("The password is required.");
    }

    internal static class CreateUser
    {
        internal static Error FirstNameIsRequired => new("The first name is required.");

        internal static Error LastNameIsRequired => new("The last name is required.");

        internal static Error EmailIsRequired => new(" The email is required.");
        
        internal static Error IsEmail => new("Enter a valid Email");

        internal static Error PasswordIsRequired => new("The password is required.");
        internal static Error CityIsRequired => new("The City is required.");

        internal static Error StreetIsRequired => new("The Street is required.");
    }
}