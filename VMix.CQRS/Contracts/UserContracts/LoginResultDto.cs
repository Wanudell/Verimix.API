namespace VMix.CQRS.Contracts.UserContracts
{
	public class LoginResultDto
	{
		public string Token { get; set; }
		public string DisplayName { get; set; }
		public string RefreshToken { get; set; }
		public int Id { get; set; }
	}
}
