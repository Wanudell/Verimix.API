namespace VMix.CQRS.Management.CommandHandlers.AuthCommandHandlers;

public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ResetPasswordRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var entity = await repository.Get(x => x.id == request.Data.id, cancellationToken);
        if((entity == null) || (entity.password != request.Data.oldPassword) || (request.Data.password != request.Data.confirmPassword))
        {
            return false;
        }
        
        request.Data.password = (request.Data.confirmPassword + entity.passwordHash).CreateHash();
        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}
