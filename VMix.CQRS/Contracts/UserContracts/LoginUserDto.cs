using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMix.CQRS.Contracts.UserContracts
{
	public class LoginUserDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
