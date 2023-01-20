namespace VMix.Data.Entities;

[Table("Permissions")]
public class Permission : BaseEntity
{
    public string route { get; set; }
    public int roleId { get; set; }
    public int? customerId { get; set; }
    public string permissions { get; set; }
}
