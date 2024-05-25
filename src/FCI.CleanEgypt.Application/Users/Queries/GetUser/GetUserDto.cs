namespace FCI.CleanEgypt.Application.Users.Queries.GetUser;

public sealed record GetUserDto(string FirstName,
    string LastName,
    string Email,
    int Year,
    int Month,
    int Day);