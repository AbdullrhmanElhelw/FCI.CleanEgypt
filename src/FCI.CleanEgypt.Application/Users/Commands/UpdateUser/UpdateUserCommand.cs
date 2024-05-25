using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand
    (
    Guid Id,
    string FirstName,
    string LastName,
    string City,
    string Street,
    int Year,
    int Month,
    int Day) : ICommand;