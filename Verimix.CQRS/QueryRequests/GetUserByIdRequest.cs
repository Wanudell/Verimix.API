namespace Verimix.CQRS.Queries
{
    public class GetUserByIdRequest : IRequest<UserByIdDto>
    {
        public GetUserByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}