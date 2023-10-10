using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dtos.Account
{
	public class JwtTokenResponseDto
	{
		public string? Token { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
