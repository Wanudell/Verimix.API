namespace VMix.CQRS.QueryRequests.NavMenuQueryRequest;

public class GetNavMenuRequest : IRequest<List<NavMenuResultDto>>
{
	public GetNavMenuRequest(string token)
	{
        Token = token;
    }

    public string Token { get; }
}
