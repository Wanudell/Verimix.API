namespace VMix.CQRS.Contracts.RoleContracts
{
    public class UpdateRoleDto
    {
        public UpdateRoleDto()
        {
            ModifiedAt = DateTime.Now;
        }

        public int Id { get; set; }

        public string RoleName { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}