using FCI.CleanEgypt.Contracts.Authentication.Settings;

namespace FCI.CleanEgypt.Infrastructure.Authentication.Settings;

public class JwtSettings : IJwtSettings
{
    public const string SettingsKey = "Jwt";

    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;
    public int ExpiryInMinutes { get; set; }
}