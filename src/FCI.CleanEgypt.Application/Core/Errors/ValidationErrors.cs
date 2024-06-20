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

        internal static Error DateOfBirthIsRequired => new("The Date of Birth is required.");

        internal static Error DateOfBirthInThePast => new("The Date of Birth must be in the past.");
    }

    internal static class UpdateUser
    {
        internal static Error FirstNameIsRequired => new("The first name is required.");

        internal static Error LastNameIsRequired => new("The last name is required.");

        internal static Error CityIsRequired => new("The city is required.");

        internal static Error StreetIsRequired => new("The street is required.");
    }

    internal static class DateOfBirth
    {
        internal static Error YearIsRequired => new("The year is required.");

        internal static Error YearMustBeLessThanCurrentYear => new("The year must be less than the current year.");

        internal static Error MonthIsRequired => new("The month is required.");

        internal static Error MonthLessThan13 => new("The month must be less than 12.");

        internal static Error DayIsRequired => new("The day is required.");

        internal static Error DayLessThan32 => new("The day must be less than 32.");

        internal static Error DateOfBirthInThePast => new("The date of birth must be in the past.");
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

    internal static class RequestPin
    {
        internal static Error UserIdIsRequired => new("The user identifier is required.");

        internal static Error AddressIsRequired => new("The address is required.");

        internal static Error DateIsRequired => new("The date is required.");

        internal static Error TypeOfWasteIsRequired => new("The type of waste is required.");
    }

    internal static class UpdatePin
    {
        internal static Error UserIdIsRequired => new("The user identifier is required.");

        internal static Error PinIdIsRequired => new("The pin identifier is required.");

        internal static Error AddressIsRequired => new("The address is required.");

        internal static Error DateIsRequired => new("The date is required.");

        internal static Error TypeOfWasteIsRequired => new("The type of waste is required.");
    }
}