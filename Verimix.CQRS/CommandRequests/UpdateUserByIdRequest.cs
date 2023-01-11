namespace Verimix.CQRS.CommandRequests
{
    public class UpdateUserByIdRequest : IRequest<bool>
    {
        public UpdateUserByIdRequest(int id, UpdateUserByIdDto data)
        {
            Id = id;
            Data = data;
        }

        public int Id { get; }
        public UpdateUserByIdDto Data { get; }
    }
}