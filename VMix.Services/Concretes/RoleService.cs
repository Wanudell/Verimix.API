namespace VMix.Services.Concretes;

internal class RoleService : IRoleService
{
    private readonly IMediator mediator;

    public RoleService(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public Task<List<GetRoleListDto>> GetAllRoles(CancellationToken cancellationToken)
    {
        return mediator.Send(new GetRoleListRequest(), cancellationToken);
    }

    public Task<GetRoleByIdDto> GetRoleById(int id, CancellationToken cancellationToken)
    {
        return mediator.Send(new GetRoleByIdRequest(id), cancellationToken);
    }

    public Task<bool> CreateRole(CreateRoleDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new CreateRoleRequest(data), cancellationToken);
    }

    public Task<bool> DeleteRoleById(int id, bool forceDelete, CancellationToken cancellationToken)
    {
        return mediator.Send(new DeleteRoleByIdRequest(id, forceDelete), cancellationToken);
    }

    public Task<bool> UpdateRole(UpdateRoleDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new UpdateRoleRequest(data), cancellationToken);
    }

    public Task<bool> UpdateRoleById(int id, UpdateRoleByIdDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new UpdateRoleByIdRequest(id, data), cancellationToken);
    }
}
