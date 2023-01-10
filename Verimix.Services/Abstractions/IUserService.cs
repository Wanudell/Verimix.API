namespace Verimix.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsers(CancellationToken cancellationToken);

        Task<UserByIdDto> GetUserById(Guid id, CancellationToken cancellationToken);

        Task<bool> CreateUser(NewUserDto data, CancellationToken cancellationToken);

        Task<bool> DeleteUserById(Guid id, bool forceDelete, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UpdateUserDto data, CancellationToken cancellationToken);

        Task<bool> UpdateUserById(Guid id, UpdateUserByIdDto data, CancellationToken cancellationToken);
    }
}