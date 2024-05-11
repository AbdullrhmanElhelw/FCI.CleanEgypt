using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Admins.Commands.Login;

public sealed record AdminLoginCommand(
    string Email,
    string Password) : ICommand;