namespace Verimix.CQRS.Commands
{
    public class NewUserRequest : IRequest<bool>
    {
        public NewUserRequest(NewUserDto data)
        {
            Data = data;
        }

        public NewUserDto Data { get; }
    }
}