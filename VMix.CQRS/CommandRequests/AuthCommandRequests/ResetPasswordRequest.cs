namespace VMix.CQRS.CommandRequests.AuthCommandRequests;

public class ResetPasswordRequest : IRequest<bool>
{
    public ResetPasswordRequest(ResetPasswordDto data)
    {
        Data = data;
    }

    public ResetPasswordDto Data { get; }
}
