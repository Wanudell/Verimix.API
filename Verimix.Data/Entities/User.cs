using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verimix.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(32)]
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}