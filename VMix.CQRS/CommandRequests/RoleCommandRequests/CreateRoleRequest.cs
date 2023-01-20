namespace VMix.CQRS.CommandRequests.RoleCommandRequests
{
    public class CreateRoleRequest : IRequest<bool>
    {
        public CreateRoleRequest(CreateRoleDto data)
        {
            Data = data;
        }

        public CreateRoleDto Data { get; }
    }
}