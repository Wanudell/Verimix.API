namespace VMix.CQRS.Contracts.UserContracts
{
    public class UpdateUserDto
    {
        public UpdateUserDto()
        {
            ModifiedAt = DateTime.Now;
        }

        public int Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}