namespace VMix.CQRS.Contracts.UserContracts
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}