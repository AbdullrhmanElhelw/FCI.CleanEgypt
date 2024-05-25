using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Domain.Entities.UserEvents;

namespace FCI.CleanEgypt.Domain.Entities.Users;

public sealed class User : BaseIdentityEntity
{
    private readonly HashSet<Pin> _pins;
    private readonly HashSet<UserEvent> _userEvents;

    private User()
    {
        _userEvents = [];
        _pins = [];
    }

    public Image? ProfilePicture { get; private set; }
    public Point? Points { get; private set; }

    public IReadOnlyCollection<UserEvent> UserEvents => _userEvents;
    public IReadOnlyCollection<Pin> Pins => _pins;

    public static User Create
    (
        string firstName,
        string lastName,
        string city,
        string street,
        DateOnly dateOfBirth,
        string email)
    {
        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            City = city,
            Street = street,
            DateOfBirth = dateOfBirth,
            Email = email,
            UserName = email[..email.IndexOf('@')]
        };
    }

    public static User Update
    (
        User user,
        string firstName,
        string lastName,
        string city,
        string street,
        DateOnly dateOfBirth)
    {
        user.FirstName = firstName;
        user.LastName = lastName;
        user.City = city;
        user.Street = street;
        user.DateOfBirth = dateOfBirth;
        return user;
    }

    public static User SetProfilePicture(User user, Image image)
    {
        user.ProfilePicture = image;
        return user;
    }
}