namespace Verimix.CQRS.Queries
{
    public class GetUserByIdRequest : IRequest<UserByIdDto>
    {
        public GetUserByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}