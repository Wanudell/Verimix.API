namespace VMix.Services.Abstractions;

public interface IUserService
{
    Task<List<GetUserListDto>> GetAllUsers(CancellationToken cancellationToken);

    Task<GetUserByIdDto> GetUserById(int id, CancellationToken cancellationToken);

    Task<GetUserByTokenDto> GetUserByToken(string token, CancellationToken cancellationToken);

    Task<bool> CreateUser(CreateUserDto data, CancellationToken cancellationToken);

    Task<bool> DeleteUserById(int id, bool forceDelete, CancellationToken cancellationToken);

    Task<bool> UpdateUser(UpdateUserDto data, CancellationToken cancellationToken);

    Task<bool> UpdateUserById(int id, UpdateUserByIdDto data, CancellationToken cancellationToken);
}