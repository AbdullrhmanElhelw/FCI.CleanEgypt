namespace FCI.CleanEgypt.Contracts.Database;

public interface ICleanEgyptDbContext
{
    Task<int> SaveChangesAsync();
}