using VMix.CQRS.Contracts.UserContracts;

namespace VMix.Services.Abstractions
{
	public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsers(CancellationToken cancellationToken);

        Task<UserByIdDto> GetUserById(int id, CancellationToken cancellationToken);

        Task<bool> CreateUser(NewUserDto data, CancellationToken cancellationToken);

        Task<bool> DeleteUserById(int id, bool forceDelete, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UpdateUserDto data, CancellationToken cancellationToken);

        Task<bool> UpdateUserById(int id, UpdateUserByIdDto data, CancellationToken cancellationToken);
    }
}