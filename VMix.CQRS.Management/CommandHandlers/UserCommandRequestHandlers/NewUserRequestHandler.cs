namespace VMix.CQRS.Management.CommandHandlers.UserCommandRequestHandlers;

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
        var repository = unitOfWork.GetRepository<AuthUser>();
        var existingUser = await repository.Get(x => x.email == request.Data.Email || x.userName == request.Data.UserName, cancellationToken);
        if (existingUser == null)
        {
            return false;
        }
        var entity = mapper.Map<AuthUser>(request.Data);
        entity.passwordHash = Guid.NewGuid().ToString();
        entity.password = (request.Data.Password + entity.passwordHash).CreateHash();
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}