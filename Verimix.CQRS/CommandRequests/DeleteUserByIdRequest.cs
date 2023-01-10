using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verimix.Services.Concretes
{
    public class DeleteUserByIdRequest : IRequest<bool>
    {
        public DeleteUserByIdRequest(Guid id, bool forceDelete)
        {
            Id = id;
            ForceDelete = forceDelete;
        }

        public Guid Id { get; set; }
        public bool ForceDelete { get; set; }
    }
}