namespace Verimix.CQRS.CommandRequests
{
    public class UpdateUserRequest : IRequest<bool>
    {
        public UpdateUserRequest(UpdateUserDto data)
        {
            Data = data;
        }

        public UpdateUserDto Data { get; }
    }
}