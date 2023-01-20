namespace VMix.CQRS.Management.CommandHandlers.RoleCommandRequestHandlers;

internal class CreateRoleRequestHandler : IRequestHandler<CreateRoleRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateRoleRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Role>();
        var existingRole = await repository.Get(x => x.roleName == request.Data.RoleName, cancellationToken);

        if (existingRole == null)
        {
            return false;
        }

        var entity = mapper.Map<Role>(request.Data);
        
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}