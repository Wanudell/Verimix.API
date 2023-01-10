using AutoMapper;

namespace Verimix.CQRS.Management.CommandHandlers
{
    internal class UpdateUserByIdCommand : IRequestHandler<UpdateUserByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUserByIdCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateUserByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            var entity = await repository.Get(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            var mapped = mapper.Map(request.Data, entity);
            repository.Update(mapped);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}