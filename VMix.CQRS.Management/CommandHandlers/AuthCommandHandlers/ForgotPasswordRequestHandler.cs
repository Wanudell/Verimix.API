namespace VMix.CQRS.Management.CommandHandlers.AuthCommandHandlers;

public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ForgotPasswordRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var entity = await repository.Get((x => x.userName == request.Data.UserName && x.email == request.Data.Email), cancellationToken);
        
        if(entity == null)
        {
            return false;
        }
        
        request.Data.Password = (request.Data.Password + request.Data.PasswordHash).CreateHash();
        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;

    }
}
