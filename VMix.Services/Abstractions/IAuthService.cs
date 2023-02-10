namespace VMix.Services.Abstractions;

public interface IAuthService
{
    Task<LoginResultDto> LoginUser(LoginUserDto data, CancellationToken cancellationToken);
    Task<bool> RegisterUser(RegisterUserDto data, CancellationToken cancellationToken);
    Task<RefreshTokenResultDto> RefreshToken(RefreshTokenDto data, CancellationToken cancellationToken);
    Task<bool> ResetPassword(ResetPasswordDto data, CancellationToken cancellationToken);
    Task<bool> ForgotPassword(ForgotPasswordDto data, CancellationToken cancellationToken);
}