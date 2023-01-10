namespace Verimix.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}