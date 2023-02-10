namespace VMix.CQRS.CommandRequests.RoleCommandRequests
{
    public class UpdateRoleRequest : IRequest<bool>
    {
        public UpdateRoleRequest(UpdateRoleDto data)
        {
            Data = data;
        }

        public UpdateRoleDto Data { get; }
    }
}