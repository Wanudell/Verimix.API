namespace VMix.CQRS.QueryRequests.RoleQueryRequests
{
    public class GetRoleByIdRequest : IRequest<GetRoleByIdDto>
    {
        public GetRoleByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}