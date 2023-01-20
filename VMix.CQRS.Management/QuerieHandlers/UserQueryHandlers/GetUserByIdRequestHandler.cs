namespace VMix.CQRS.Management.QuerieHandlers.UserQueryHandlers;

public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserByIdRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<GetUserByIdDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        return repository.Get<GetUserByIdDto>(x => x.id == request.Id, cancellationToken);
    }
}