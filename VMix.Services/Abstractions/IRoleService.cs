namespace VMix.Services.Abstractions;

public interface IRoleService
{
    Task<List<GetRoleListDto>> GetAllRoles(CancellationToken cancellationToken);

    Task<GetRoleByIdDto> GetRoleById(int id, CancellationToken cancellationToken);

    Task<bool> CreateRole(CreateRoleDto data, CancellationToken cancellationToken);

    Task<bool> DeleteRoleById(int id, bool forceDelete, CancellationToken cancellationToken);

    Task<bool> UpdateRole(UpdateRoleDto data, CancellationToken cancellationToken);

    Task<bool> UpdateRoleById(int id, UpdateRoleByIdDto data, CancellationToken cancellationToken);
}
