namespace VMix.CQRS.CommandRequests;

public class RefreshTokenRequest : IRequest<RefreshTokenResultDto>
{
	public RefreshTokenRequest(RefreshTokenDto data)
	{
		Data = data;
	}

	public RefreshTokenDto Data { get; }
}
