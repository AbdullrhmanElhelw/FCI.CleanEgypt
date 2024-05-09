namespace FCI.CleanEgypt.Persistence.Infrastructure;

public sealed class ConnectionString(string value)
{
    public const string SettingsKey = "CleanEgyptDb";
    public string Value { get; } = value;

    public static implicit operator string(ConnectionString connectionString)
    {
        return connectionString.Value;
    }
}