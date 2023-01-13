namespace VMix.CQRS.Management.CommandHandlers;

internal class DeleteUserRequestHandler : IRequestHandler<DeleteUserByIdRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteUserRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var entity = await repository.Get(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);
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
            entity.DeletedAt = DateTime.Now;
            entity.IsDeleted = true;
            entity.IsActive = false;
            repository.Update(entity);
        }
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}