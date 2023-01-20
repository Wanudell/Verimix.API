namespace VMix.CQRS.Management.CommandHandlers.UserCommandRequestHandlers;

internal class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, bool>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
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