namespace VMix.CQRS.CommandRequests
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
