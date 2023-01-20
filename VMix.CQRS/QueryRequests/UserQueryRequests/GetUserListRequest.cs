namespace VMix.CQRS.QueryRequests.UserQueryRequest
{
    public class GetUserListRequest : IRequest<List<GetUserListDto>>  //IRequest MediatR paketinden gelen bir interface'dir.
    {
    }
}