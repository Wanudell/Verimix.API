namespace VMix.Data.Entities;

[Table("AuthPermissions")]
public class AuthPermission : BaseEntity
{
    public string route { get; set; }
    public int roleId { get; set; }
    public string permission { get; set; }
}
