namespace VMix.CQRS.Management.CommandHandlers.UserCommandRequestHandlers;

internal class UpdateUserByIdRequestHandler : IRequestHandler<UpdateUserByIdRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateUserByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateUserByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var entity = await repository.Get(x => !x.isDeleted && x.id == request.Id, cancellationToken);
        if (entity == null)
        {
            return false;
        }
        if (entity.token == null)
        {
            return false;
        }
        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}