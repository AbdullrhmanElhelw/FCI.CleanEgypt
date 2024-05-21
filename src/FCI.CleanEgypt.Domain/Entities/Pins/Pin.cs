using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Admins;
using FCI.CleanEgypt.Domain.Entities.Users;

namespace FCI.CleanEgypt.Domain.Entities.Pins;

public sealed class Pin : BaseEntity
{
    private Pin()
    {
    }

    public string City { get; private set; }
    public string Street { get; private set; }

    public string Description { get; private set; }

    public Image? Image { get; private set; }
    public bool IsApproved { get; private set; }

    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public Guid? AdminId { get; }
    public Admin? Admin { get; }

    public static Pin Create(
        string city,
        string street,
        string description,
        Guid userId,
        Image? image = null)
    {
        return new Pin
        {
            City = city,
            Street = street,
            UserId = userId,
            IsApproved = false,
            Description = description,
            Image = image
        };
    }

    public static Pin Update(
        Pin pin,
        string city,
        string street,
        string description,
        Image? image = null)
    {
        pin.City = city;
        pin.Street = street;
        pin.Description = description;
        pin.Image = image;
        return pin;
    }
}