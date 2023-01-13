using Microsoft.Identity.Client;

namespace VMix.Services.Abstractions
{
	public interface IAuthenticationService
    {
        Task<LoginResultDto> LoginUser(LoginUserDto data, CancellationToken cancellationToken);
        Task<bool> RegisterUser(RegisterUserDto data, CancellationToken cancellationToken);
		Task<RefreshTokenResultDto> RefreshToken(RefreshTokenDto data, CancellationToken cancellationToken);
	}
}