namespace VMix.CQRS.Management.Commands;

internal class NewUserRequestHandler : IRequestHandler<NewUserRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public NewUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(NewUserRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var existingUser = await repository.Get(x => x.Email == request.Data.Email || x.UserName == request.Data.UserName, cancellationToken);
        if (existingUser == null)
        {
            return false;
        }
        var entity = mapper.Map<User>(request.Data);
        entity.PasswordHash = Guid.NewGuid().ToString();
        entity.Password = (request.Data.Password + entity.PasswordHash).CreateHash();
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}