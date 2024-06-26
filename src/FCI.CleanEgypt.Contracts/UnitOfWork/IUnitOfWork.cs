namespace FCI.CleanEgypt.Contracts.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}