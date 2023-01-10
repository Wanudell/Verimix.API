using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verimix.CQRS.Contracts
{
    public class UpdateUserByIdDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}