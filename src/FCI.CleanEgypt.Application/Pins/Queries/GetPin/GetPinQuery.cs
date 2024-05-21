using FCI.CleanEgypt.Contracts.CQRS.Queries;

namespace FCI.CleanEgypt.Application.Pins.Queries.GetPin;

public sealed record GetPinQuery
    (Guid UserId,
    Guid PinId) : IQuery<GetPinResponse>;