namespace VMix.CQRS.Contracts.UserContracts
{
    public class GetUserListDto
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public int roleId { get; set; }
    }
}