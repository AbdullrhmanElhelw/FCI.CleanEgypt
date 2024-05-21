namespace FCI.CleanEgypt.Application.Users.Queries.GetProfilePicture;

public sealed record GetProfilePictureResponse(
    string FileName,
    string ContentType,
    byte[] Data);