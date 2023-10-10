using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dtos.Account
{
	public class UserLoginDto
	{
		public string? EmailorUsername { get; set; }
		public string? Password { get; set; }
	}
}
