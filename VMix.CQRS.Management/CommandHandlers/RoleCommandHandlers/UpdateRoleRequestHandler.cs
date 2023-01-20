namespace VMix.CQRS.Management.CommandHandlers.RoleCommandRequestHandlers;

internal class UpdateRoleRequestHandler : IRequestHandler<UpdateRoleRequest, bool>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateRoleRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Role>();
        var entity = await repository.Get(f => f.id == request.Data.Id, cancellationToken);
        
        if (entity is null)
        {
            return false;
        }
        
        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);

        return result > 0;
    }
}