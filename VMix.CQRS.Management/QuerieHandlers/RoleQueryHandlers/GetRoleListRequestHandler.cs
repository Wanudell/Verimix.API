namespace VMix.CQRS.Management.QuerieHandlers.RoleQueryHandlers;

public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, List<GetRoleListDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetRoleListRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<List<GetRoleListDto>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
    //Handle methodu GetRoleListRequest'i giriş Task<List<Role>>'ı da dönüş olarak kullanıyor.
    {
        var repository = unitOfWork.GetRepository<AuthUser>();
        return repository.GetAll<GetRoleListDto>(x => x.isDeleted == false, cancellationToken);
    }
}
