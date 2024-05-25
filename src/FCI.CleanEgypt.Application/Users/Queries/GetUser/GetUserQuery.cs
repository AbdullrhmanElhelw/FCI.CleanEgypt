using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Users.Queries.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<GetUserDto>;