using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Admins;
using FCI.CleanEgypt.Domain.Entities.Users;

namespace FCI.CleanEgypt.Domain.Entities.Pins;

public sealed class Pin : BaseEntity
{
    private Pin()
    {
    }

    public string City { get; }
    public string Street { get; }


    public Guid UserId { get; }
    public User User { get; }

    public Guid AdminId { get; }
    public Admin Admin { get; }
}