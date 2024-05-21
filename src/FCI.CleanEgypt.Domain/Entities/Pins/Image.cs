namespace FCI.CleanEgypt.Domain.Entities.Pins;

public sealed record Image
{
    public string FileName { get; private init; }
    public string ContentType { get; private init; }
    public byte[] Data { get; private init; }

    private Image(string fileName, string contentType, byte[] data)
    {
        FileName = fileName;
        ContentType = contentType;
        Data = data;
    }

    public static Image Create(string fileName, string contentType, byte[] data)
        => new(fileName, contentType, data);
}