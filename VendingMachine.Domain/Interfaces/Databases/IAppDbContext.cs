namespace VendingMachine.Domain.Interfaces.Databases
{
    public interface IAppDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
