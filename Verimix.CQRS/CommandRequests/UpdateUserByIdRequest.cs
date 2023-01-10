namespace Verimix.CQRS.CommandRequests
{
    public class UpdateUserByIdRequest : IRequest<bool>
    {
        public UpdateUserByIdRequest(Guid id, UpdateUserByIdDto data)
        {
            Id = id;
            Data = data;
        }

        public Guid Id { get; }
        public UpdateUserByIdDto Data { get; }
    }
}