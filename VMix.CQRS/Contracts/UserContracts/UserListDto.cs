namespace VMix.CQRS.Contracts.UserContracts
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}