namespace VMix.CQRS.Contracts.AuthContracts;

public class RegisterUserDto
{
    public RegisterUserDto()
    {
        firstLoginDate = DateTime.Now;
    }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime firstLoginDate { get; set; }
}
