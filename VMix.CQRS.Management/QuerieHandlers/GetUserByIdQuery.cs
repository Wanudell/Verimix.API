namespace VMix.CQRS.Management.Queries;

public class GetUserByIdQuery : IRequestHandler<GetUserByIdRequest, UserByIdDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserByIdQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<UserByIdDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        return repository.Get<UserByIdDto>(x => x.Id == request.Id, cancellationToken);
    }
}