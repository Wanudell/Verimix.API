namespace VMix.CQRS.CommandRequests.RoleCommandRequests;

public class UpdateRoleByIdRequest : IRequest<bool>
{
    public UpdateRoleByIdRequest(int id, UpdateRoleByIdDto data)
    {
        Id = id;
        Data = data;
    }

    public int Id { get; }
    public UpdateRoleByIdDto Data { get; }
}