using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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