namespace Verimix.Services.Concretes
{
    internal class UserService : IUserService
    {
        private readonly IMediator mediator;

        public UserService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<List<User>> GetUsers(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetUserListRequest(), cancellationToken);
        }
    }
}