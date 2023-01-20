namespace VMix.CQRS.Contracts.RoleContracts
{
    public class UpdateRoleByIdDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}