using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Admins;
using FCI.CleanEgypt.Domain.Entities.Users;

namespace FCI.CleanEgypt.Domain.Entities.Pins;

public sealed class Pin : BaseEntity
{
    private Pin()
    {
    }

    public string TypeOfWaste { get; private set; }
    public string Address { get; private set; }
    public string Date { get; private set; }

    public double? Longitude { get; private set; }
    public double? Latitude { get; private set; }

    public Image? Image { get; private set; }
    public bool IsApproved { get; private set; }

    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public Guid? AdminId { get; }
    public Admin? Admin { get; }

    public static Pin Create(string typeOfWaste, string address, string date,
        double? longitude, double? latitude, Image? image, Guid userId)
    {
        return new Pin
        {
            TypeOfWaste = typeOfWaste,
            Address = address,
            Date = date,
            Longitude = longitude,
            Latitude = latitude,
            Image = image,
            UserId = userId
        };
    }

    public static Pin GetPin(Guid id, string typeOfWaste, string address, string date)
    {
        return new Pin
        {
            Id = id,
            TypeOfWaste = typeOfWaste,
            Address = address,
            Date = date
        };
    }

    public static Pin UpdatePin(Pin pin, string typeOfWaste, string address, string date)
    {
        pin.TypeOfWaste = typeOfWaste;
        pin.Address = address;
        pin.Date = date;

        return pin;
    }

    public static Pin Delete(Pin pin)
    {
        pin.IsDeleted = true;
        return pin;
    }
}