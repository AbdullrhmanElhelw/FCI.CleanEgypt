using FCI.CleanEgypt.Contracts.CQRS.Commands;

namespace FCI.CleanEgypt.Application.Admins.Commands.CreateAdmin;

public sealed record CreateAdminCommand(
    string FirstName,
    string LastName,
    string City,
    string Street,
    int Year,
    int Month,
    int Day,
    string Email,
    string Password) : ICommand;