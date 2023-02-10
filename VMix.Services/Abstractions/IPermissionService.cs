namespace VMix.Services.Abstractions;

public interface IPermissionService
{
    Task<bool> CheckPermission(CheckPermissionDto data, CancellationToken cancellationToken);
}
