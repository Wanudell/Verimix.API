namespace Verimix.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<User>> GetUsers(CancellationToken cancellationToken);
    }
}