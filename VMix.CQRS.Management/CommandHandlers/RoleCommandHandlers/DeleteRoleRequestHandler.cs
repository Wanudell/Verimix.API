namespace VMix.CQRS.Management.CommandHandlers.RoleCommandRequestHandlers;

internal class DeleteRoleRequestHandler : IRequestHandler<DeleteRoleByIdRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteRoleRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteRoleByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<AuthRole>();
        var entity = await repository.Get(x => x.isDeleted == false && x.id == request.Id, cancellationToken);
        if (entity == null)
        {
            return false;
        }
        if (request.ForceDelete)
        {
            repository.Delete(entity);
        }
        else
        {
            entity.deletedAt = DateTime.Now;
            entity.isDeleted = true;
            entity.isActive = false;
            repository.Update(entity);
        }
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}