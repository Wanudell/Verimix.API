namespace VMix.CQRS.QueryRequests.UserQueryRequest;

public class GetUserByTokenRequest : IRequest<GetUserByTokenDto>
{
    public GetUserByTokenRequest(string token)
    {
        Token = token;
    }
    public string Token { get; set; }
}
