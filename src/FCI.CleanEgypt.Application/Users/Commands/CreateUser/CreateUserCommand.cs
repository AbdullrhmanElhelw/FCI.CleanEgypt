using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string City,
    string Street,
    int Year,
    int Month,
    int Day,
    string Email,
    string Password) : ICommand;