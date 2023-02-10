namespace VMix.CQRS.Contracts.PermissionContracts;

public class PermissionDto
{
    public string route { get; set; }
    public int roleId { get; set; }
    public int? customerId { get; set; }
    public string permissions { get; set; }
}

