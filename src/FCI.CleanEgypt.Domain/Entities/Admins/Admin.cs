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
}