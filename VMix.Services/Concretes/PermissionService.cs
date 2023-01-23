namespace VMix.Services.Concretes;

internal class PermissionService : IPermissionService
{
    private readonly IMediator mediator;

    public PermissionService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<bool> CheckPermission(CheckPermissionDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new CheckPermissionRequest(data), cancellationToken);
    }
}
