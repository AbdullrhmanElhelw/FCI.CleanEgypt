using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Pins;

namespace FCI.CleanEgypt.Domain.Entities.Admins;

public sealed class Admin : BaseIdentityEntity
{
    private readonly HashSet<Pin> _pins;

    private Admin()
    {
        _pins = [];
    }

    public Image? ProfilePicture { get; }
    public IReadOnlyCollection<Pin> Pins => _pins;

    public static Admin Create(
        string fName,
        string lName,
        string city,
        string street,
        DateOnly dateOfBirth,
        string email)
    {
        return new Admin
        {
            FirstName = fName,
            LastName = lName,
            City = city,
            Street = street,
            DateOfBirth = dateOfBirth,
            Email = email,
            UserName = email[..email.IndexOf('@')]
        };
    }
}