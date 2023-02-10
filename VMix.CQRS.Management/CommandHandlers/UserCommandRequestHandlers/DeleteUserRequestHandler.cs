namespace VMix.CQRS.Management.CommandHandlers.UserCommandRequestHandlers;

internal class DeleteUserRequestHandler : IRequestHandler<DeleteUserByIdRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteUserRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<AuthUser>();
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