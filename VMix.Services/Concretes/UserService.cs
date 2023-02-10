namespace VMix.Services.Concretes;

internal class UserService : IUserService
{
    private readonly IMediator mediator;

    public UserService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<List<GetUserListDto>> GetAllUsers(CancellationToken cancellationToken)
    {
        return mediator.Send(new GetUserListRequest(), cancellationToken);
    }

    public Task<GetUserByIdDto> GetUserById(int id, CancellationToken cancellationToken)
    {
        return mediator.Send(new GetUserByIdRequest(id), cancellationToken);
    }

    public Task<bool> CreateUser(CreateUserDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new NewUserRequest(data), cancellationToken);
    }

    public Task<bool> DeleteUserById(int id, bool forceDelete, CancellationToken cancellationToken)
    {
        return mediator.Send(new DeleteUserByIdRequest(id, forceDelete), cancellationToken);
    }

    public Task<bool> UpdateUser(UpdateUserDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new UpdateUserRequest(data), cancellationToken);
    }

    public Task<bool> UpdateUserById(int id, UpdateUserByIdDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new UpdateUserByIdRequest(id, data), cancellationToken);
    }

    public Task<GetUserByTokenDto> GetUserByToken(string token, CancellationToken cancellationToken)
    {
        return mediator.Send(new GetUserByTokenRequest(token), cancellationToken);
    }
}