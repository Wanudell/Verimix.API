namespace Verimix.Data.Concretes
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;
        private readonly IMapper mapper;

        public UnitOfWork(DbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(dbContext, mapper);
        }

        public Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}