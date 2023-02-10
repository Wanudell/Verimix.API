namespace VMix.CQRS.Contracts.AuthContracts;

public class LoginUserDto
{
    public LoginUserDto()
    {
        lastLoginDate = DateTime.Now;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime lastLoginDate { get; set; }
}
