namespace VMix.CQRS.QueryRequests.UserQueryRequest
{
    public class GetUserByIdRequest : IRequest<GetUserByIdDto>
    {
        public GetUserByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}