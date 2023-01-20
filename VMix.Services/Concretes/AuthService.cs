namespace VMix.Services.Concretes;

internal class AuthService : IAuthService
{
    private readonly IMediator mediator;

    public AuthService(IMediator mediator)
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

    public Task<bool> RegisterUser(RegisterUserDto data, CancellationToken cancellationToken)
    {
        return this.mediator.Send(new RegisterUserRequest(data), cancellationToken);
    }

    public Task<bool> ResetPassword(ResetPasswordDto data, CancellationToken cancellationToken)
    {
        return this.mediator.Send(new ResetPasswordRequest(data), cancellationToken);
    }

    public Task<bool> ForgotPassword(ForgotPasswordDto data, CancellationToken cancellationToken)
    {
        return this.mediator.Send(new ForgotPasswordRequest(data), cancellationToken);
    }
}