namespace Verimix.CQRS.Management.Queries
{
    public class GetUserListQuery : IRequestHandler<GetUserListRequest, List<User>> //Request ile gelecek List ile dönecek.
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        //Handle methodu GetUserlistRequest'i giriş Task<List<User>>'ı da dönüş olarak kullanıyor.
        {
            var repository = unitOfWork.GetRepository<User>();
            var result = await repository.GetAll(x => true, cancellationToken);
            return result;
        }
    }
}