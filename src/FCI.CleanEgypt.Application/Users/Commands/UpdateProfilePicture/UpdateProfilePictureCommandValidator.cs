using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Application.Core.Extensions;
using FluentValidation;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateProfilePicture;

public sealed class UpdateProfilePictureCommandValidator
    : AbstractValidator<UpdateProfilePictureCommand>
{
    public UpdateProfilePictureCommandValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty()
           .WithError(ValidationErrors.SetProfilePicture.UserIdIsRequired.Message);

        RuleFor(x => x.Picture)
            .NotNull()
            .WithError(ValidationErrors.SetProfilePicture.PictureIsRequired);

        RuleFor(x => x.Picture.Length)
            .LessThanOrEqualTo(5 * 1024 * 1024)
            .WithError(ValidationErrors.SetProfilePicture.PictureSizeExceeds5Mb);

        RuleFor(x => x.Picture.ContentType)
            .Must(x => x is "image/jpeg" or "image/png")
            .WithError(ValidationErrors.SetProfilePicture.PictureMustBeInJpegOrPngFormat);
    }
}