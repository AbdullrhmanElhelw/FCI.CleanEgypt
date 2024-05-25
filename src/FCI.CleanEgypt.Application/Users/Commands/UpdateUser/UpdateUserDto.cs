namespace FCI.CleanEgypt.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserDto
    (string FirstName,
     string LastName,
     string City,
     string Street,
     int Year,
     int Month,
     int Day);