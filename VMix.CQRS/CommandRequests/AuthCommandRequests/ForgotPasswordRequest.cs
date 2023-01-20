namespace VMix.CQRS.CommandRequests.AuthCommandRequests;

public class ForgotPasswordRequest : IRequest<bool>
{
    public ForgotPasswordRequest(ForgotPasswordDto data)
    {
        Data = data;
    }

    public ForgotPasswordDto Data { get; }
}
