namespace VMix.CQRS.Management.CommandHandlers.RoleCommandRequestHandlers;

internal class UpdateRoleByIdRequestHandler : IRequestHandler<UpdateRoleByIdRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateRoleByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateRoleByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Role>();
        var entity = await repository.Get(x => !x.isDeleted && x.id == request.Id, cancellationToken);

        if (entity == null)
        {
            return false;
        }

        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);

        return result > 0;
    }
}