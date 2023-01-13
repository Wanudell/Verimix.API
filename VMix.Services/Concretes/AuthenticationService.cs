namespace VMix.Services.Concretes
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly IMediator mediator;

		public AuthenticationService(IMediator mediator)
		{
			this.mediator = mediator;
		}
		public Task<LoginResultDto> LoginUser(LoginUserDto data, CancellationToken cancellationToken)
		{
			return this.mediator.Send(new LoginUserRequest(data), cancellationToken);
		}

		public Task<RefreshTokenResultDto> RefreshToken(RefreshTokenDto data, CancellationToken cancellationToken)
		{
			return this.mediator.Send(new RefreshTokenRequest(data), cancellationToken);
		}

		public  Task<bool> RegisterUser(RegisterUserDto data, CancellationToken cancellationToken)
		{
			return this.mediator.Send(new RegisterUserRequest(data), cancellationToken);
		}
	}
}
