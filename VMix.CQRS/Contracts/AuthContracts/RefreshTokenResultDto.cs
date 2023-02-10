namespace VMix.CQRS.Contracts.AuthContracts;

public class RefreshTokenResultDto
{
    public string Token { get; set; }
    public DateTime ExpiresInMinutes { get; set; }
    public string RefreshToken { get; set; }
    public int Id { get; set; }
}
