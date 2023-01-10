using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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