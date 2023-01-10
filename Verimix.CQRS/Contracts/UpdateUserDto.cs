using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verimix.CQRS.Contracts
{
    public class UpdateUserDto
    {
        public UpdateUserDto()
        {
            ModifiedAt = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}