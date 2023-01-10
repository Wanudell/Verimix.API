namespace Verimix.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsers(CancellationToken cancellationToken);

        Task<UserByIdDto> GetUserById(Guid id, CancellationToken cancellationToken);

        Task<bool> CreateUser(NewUserDto data, CancellationToken cancellationToken);

        Task<bool> DeleteUserById(Guid id, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UpdateUserDto data, CancellationToken cancellationToken);
    }
}