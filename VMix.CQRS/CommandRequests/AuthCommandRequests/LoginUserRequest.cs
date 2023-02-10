using VMix.CQRS.Contracts.AuthContracts;

namespace VMix.CQRS.CommandRequests.AuthCommandRequests;

public class LoginUserRequest : IRequest<LoginResultDto>
{
    public LoginUserRequest(LoginUserDto data)
    {
        Data = data;
    }

    public LoginUserDto Data { get; }
}
