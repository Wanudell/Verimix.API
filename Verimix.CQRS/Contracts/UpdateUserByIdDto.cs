namespace Verimix.CQRS.Contracts
{
    public class UpdateUserByIdDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}