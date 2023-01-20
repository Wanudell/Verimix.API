namespace VMix.CQRS.CommandRequests.RoleCommandRequests
{
    public class DeleteRoleByIdRequest : IRequest<bool>
    {
        public DeleteRoleByIdRequest(int id, bool forceDelete)
        {
            Id = id;
            ForceDelete = forceDelete;
        }

        public int Id { get; set; }
        public bool ForceDelete { get; }
    }
}