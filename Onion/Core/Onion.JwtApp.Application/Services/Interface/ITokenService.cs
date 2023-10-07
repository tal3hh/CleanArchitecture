using Onion.JwtApp.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services.Interface
{
    public interface ITokenService
    {
        TokenResponseDto GenerateJwtToken(string username, List<string> roles);
    }
}
