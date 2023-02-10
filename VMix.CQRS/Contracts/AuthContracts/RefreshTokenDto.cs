namespace VMix.CQRS.Contracts.AuthContracts;

public class RefreshTokenDto
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public Guid RefreshToken { get; set; }
    public int Id { get; set; }
}
