namespace Verimix.CQRS.Queries
{
    public class GetUserListRequest : IRequest<List<UserListDto>>  //IRequest MediatR paketinden gelen bir interface'dir.
    {
    }
}