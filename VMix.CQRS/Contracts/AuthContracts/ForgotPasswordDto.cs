namespace VMix.CQRS.Contracts.AuthContracts;

public class ForgotPasswordDto
{
    public ForgotPasswordDto(string PasswordHash)
    {
        this.PasswordHash = Guid.NewGuid().ToString();
    }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
}
