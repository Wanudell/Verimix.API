namespace VMix.CQRS.Management.QuerieHandlers.RoleQueryHandlers;

public class GetRoleByIdRequestHandler : IRequestHandler<GetRoleByIdRequest, GetRoleByIdDto>
{
    private readonly IUnitOfWork unitOfWork;

    public GetRoleByIdRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<GetRoleByIdDto> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<AuthRole>();
        return repository.Get<GetRoleByIdDto>(x => x.id == request.Id, cancellationToken);
    }
}