using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Users.Queries.GetProfilePicture;

public sealed record GetProfilePictureQuery(Guid UserId) : IQuery<GetProfilePictureResponse>;