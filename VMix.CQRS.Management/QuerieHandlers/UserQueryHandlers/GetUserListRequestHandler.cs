namespace VMix.CQRS.Management.QuerieHandlers.UserQueryHandlers;

public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<GetUserListDto>> //Request ile gelecek List ile dönecek.
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserListRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<List<GetUserListDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
    //Handle methodu GetUserlistRequest'i giriş Task<List<User>>'ı da dönüş olarak kullanıyor.
    {
        var repository = unitOfWork.GetRepository<AuthUser>();
        return repository.GetAll<GetUserListDto>(x => x.isDeleted == false, cancellationToken);
    }
}