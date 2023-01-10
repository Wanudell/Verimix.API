namespace Verimix.CQRS.Management.Queries
{
    public class GetUserListQuery : IRequestHandler<GetUserListRequest, List<UserListDto>> //Request ile gelecek List ile dönecek.
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<UserListDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        //Handle methodu GetUserlistRequest'i giriş Task<List<User>>'ı da dönüş olarak kullanıyor.
        {
            var repository = unitOfWork.GetRepository<User>();
            return repository.GetAll<UserListDto>(x => !x.IsDeleted, cancellationToken);
        }
    }
}