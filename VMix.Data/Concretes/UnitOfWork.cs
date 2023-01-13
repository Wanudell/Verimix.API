namespace VMix.Data.Concretes;

internal class UnitOfWork : IUnitOfWork
{
	private readonly DbContext dbContext;
	private readonly IMapper mapper;
	private readonly IClaims claims;

	public UnitOfWork(DbContext dbContext, IMapper mapper, IClaims claims)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
		this.claims = claims;
	}

	public IRepository<T> GetRepository<T>() where T : BaseEntity
	{
		return new Repository<T>(dbContext, mapper, claims);
	}

	public Task<int> SaveChanges(CancellationToken cancellationToken)
	{
		return dbContext.SaveChangesAsync(cancellationToken);
	}
}