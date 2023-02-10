namespace VMix.CQRS.Contracts.RoleContracts
{
    public class GetRoleByIdDto
    {
        public GetRoleByIdDto()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}