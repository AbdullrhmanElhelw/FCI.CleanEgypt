using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Users.Commands.Login;

public sealed record UserLoginCommand(
    string Email,
    string Password) : ICommand;