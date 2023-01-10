namespace Verimix.CQRS.Queries
{
    public class GetUserListRequest : IRequest<List<User>>  //IRequest MediatR paketinden gelen bir interface'dir.
    {
    }
}