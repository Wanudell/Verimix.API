namespace VMix.CQRS.Contracts.UserContracts;

public class RefreshTokenResultDto
{
	public DateTime ExpiresInMinutes { get; set; }
	public string RefreshToken { get; set; }
	public int Id { get; set; }
}
