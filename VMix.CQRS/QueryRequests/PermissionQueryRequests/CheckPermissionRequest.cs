namespace VMix.CQRS.QueryRequests.PermissionQueryRequests;

public class CheckPermissionRequest : IRequest<bool>
{
	public CheckPermissionRequest(CheckPermissionDto data)
	{
        Data = data;
    }

    public CheckPermissionDto Data { get; }
}
