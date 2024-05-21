namespace FCI.CleanEgypt.Domain.Entities.Users;

public sealed record Image
{
    private Image(string fileName, string contentType, byte[] data)
    {
        FileName = fileName;
        ContentType = contentType;
        Data = data;
    }
    public string FileName { get; private set; }
    public string ContentType { get; private set; }
    public byte[] Data { get; private set; }
    public static Image Create(string fileName, string contentType, byte[] data) =>
        new Image(fileName, contentType, data);
}