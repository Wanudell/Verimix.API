namespace VMix.CQRS.Contracts.AuthContracts
{
    public class RegisterUserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
