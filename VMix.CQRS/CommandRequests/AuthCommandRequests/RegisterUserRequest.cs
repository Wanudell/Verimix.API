using VMix.CQRS.Contracts.AuthContracts;

namespace VMix.CQRS.CommandRequests.AuthCommandRequests
{
    public class RegisterUserRequest : IRequest<bool>
    {
        public RegisterUserRequest(RegisterUserDto data)
        {
            Data = data;
        }

        public RegisterUserDto Data { get; }
    }
}
