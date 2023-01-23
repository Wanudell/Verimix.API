namespace VMix.Data.Entities;

[Table("AuthRoles")]
public class AuthRole : BaseEntity
{
    public string roleName { get; set; }
}
