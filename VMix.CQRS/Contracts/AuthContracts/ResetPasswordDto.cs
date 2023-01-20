namespace VMix.CQRS.Contracts.AuthContracts;

public class ResetPasswordDto
{
    public ResetPasswordDto(string passwordHash)
    {
        this.passwordHash = Guid.NewGuid().ToString();
    }
    public int id { get; set; }
    public string oldPassword { get; set; }
    public string password { get; set; }
    public string passwordHash { get; set; }
    public string confirmPassword { get; set; }
}
