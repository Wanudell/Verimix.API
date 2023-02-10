namespace VMix.CQRS.CommandRequests.UserCommandRequests
{
    public class NewUserRequest : IRequest<bool>
    {
        public NewUserRequest(CreateUserDto data)
        {
            Data = data;
        }

        public CreateUserDto Data { get; }
    }
}