using FCI.CleanEgypt.Contracts.ApiResponse.Results;

namespace FCI.CleanEgypt.Application.Core.Errors;

internal static class ValidationErrors
{
    internal static class Login
    {
        internal static Error EmailIsRequired => new("The email is required.");
        internal static Error IsEmail => new("Enter a valid Email");
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

    internal static class CreateAdmin
    {
        internal static Error FirstNameIsRequired => new("The first name is required.");

        internal static Error LastNameIsRequired => new("The last name is required.");

        internal static Error EmailIsRequired => new(" The email is required.");

        internal static Error IsEmail => new("Enter a valid Email");

        internal static Error PasswordIsRequired => new("The password is required.");
        internal static Error CityIsRequired => new("The City is required.");

        internal static Error StreetIsRequired => new("The Street is required.");
    }

    internal static class CreateEvent
    {
        internal static Error NameIsRequired => new("Event Name is Required");
        internal static Error DateIsRequired => new("Event Date is Required");
        internal static Error DateInTheFuture => new("Event Date Must be in the future");
        internal static Error DetailsAreRequired => new("Details are Required ");
    }

    internal static class UpdateEvent
    {
        internal static Error NameIsRequired => new("Event Name is Required");
        internal static Error DateIsRequired => new("Event Date is Required");
        internal static Error DateInTheFuture => new("Event Date Must be in the future");
        internal static Error DetailsAreRequired => new("Details are Required ");
        internal static Error EventIsNotExists => new("Event is not exists");
    }


    internal static class SetProfilePicture
    {
        internal static Error UserIdIsRequired => new("The user identifier is required.");

        internal static Error PictureIsRequired => new("The picture is required.");

        internal static Error PictureSizeExceeds5Mb => new("The picture size must not exceed 5MB.");

        internal static Error PictureMustBeInJpegOrPngFormat => new("The picture must be in JPEG or PNG format.");
    }
}