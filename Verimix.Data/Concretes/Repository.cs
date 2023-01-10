namespace Verimix.Data.Concretes
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.IsActive = false;
            Update(entity);
        }

        public Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return dbContext.Set<T>().SingleOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        public Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return dbContext.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        //public Task<TDto> Get<TDto>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        //{
        //    return dbContext.Set<T>().Where(predicate).ProjectTo<TDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken);
        //}

        public Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        //public Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        //{
        //    return dbContext.Set<T>().Where(predicate).ProjectTo<TDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        //}

        //public Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, Expression<Func<TDto, object>> order, CancellationToken cancellationToken)
        //{
        //    return dbContext.Set<T>().Where(predicate).ProjectTo<TDto>(mapper.ConfigurationProvider).OrderBy(order).ToListAsync(cancellationToken);
        //}

        public void Insert(T entity)
        {
            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.ModifiedAt = DateTime.Now;
            dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
            dbContext.Set<T>().Update(entity);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await Get(id, cancellationToken);
            entity.IsDeleted = true;
            entity.IsActive = false;
            Update(entity);
        }
    }
}