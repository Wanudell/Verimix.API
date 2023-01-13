namespace VMix.CQRS.CommandRequests;

public class LoginUserRequest : IRequest<LoginResultDto>
{
	public LoginUserRequest(LoginUserDto data)
	{
		Data = data;
	}

	public LoginUserDto Data { get; }
}
