namespace VMix.CQRS.Contracts.PermissionContracts;

public class CheckPermissionDto
{
    public string Token { get; set; }
	public string Route { get; set; }
}
