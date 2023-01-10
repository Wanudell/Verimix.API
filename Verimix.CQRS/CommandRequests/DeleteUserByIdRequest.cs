using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verimix.Services.Concretes
{
    public class DeleteUserByIdRequest : IRequest<bool>
    {
        public DeleteUserByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}