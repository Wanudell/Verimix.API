namespace Verimix.CQRS.Management.Commands
{
    internal class NewUserCommand : IRequestHandler<NewUserRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewUserCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            var entity = mapper.Map<User>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}