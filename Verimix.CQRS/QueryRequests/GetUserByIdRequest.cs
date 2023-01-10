using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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