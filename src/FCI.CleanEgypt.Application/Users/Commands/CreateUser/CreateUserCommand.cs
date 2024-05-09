using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string City,
    string Street,
    DateTime DateOfBirth,
    string Email,
    string Password) : ICommand;