namespace VMix.CQRS.Contracts.UserContracts;

public class RefreshTokenDto
{
	public string Token { get; set; }
	public Guid RefreshToken { get; set; }
	public int Id { get; set; }
}
