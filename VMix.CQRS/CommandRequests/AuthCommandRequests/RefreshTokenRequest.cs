using VMix.CQRS.Contracts.AuthContracts;

namespace VMix.CQRS.CommandRequests.AuthCommandRequests;

public class RefreshTokenRequest : IRequest<RefreshTokenResultDto>
{
    public RefreshTokenRequest(RefreshTokenDto data)
    {
        Data = data;
    }

    public RefreshTokenDto Data { get; }
}
