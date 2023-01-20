namespace VMix.Data.Entities;

[Table("Roles")]
public class Role : BaseEntity
{
    public string roleName { get; set; }
}
