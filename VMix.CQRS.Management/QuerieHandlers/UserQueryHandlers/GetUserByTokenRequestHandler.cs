namespace VMix.CQRS.Management.QuerieHandlers.UserQueryHandlers;

public class GetUserByTokenRequestHandler : IRequestHandler<GetUserByTokenRequest, GetUserByTokenDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserByTokenRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GetUserByTokenDto> Handle(GetUserByTokenRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        return await repository.Get<GetUserByTokenDto>(x => x.token == request.Token, cancellationToken);
    }
}

