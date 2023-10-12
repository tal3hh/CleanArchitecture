using MediatR;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class LoginUserCommandRequest : IRequest<TokenResponseDto?>
    {
        public string? EmailorUsername { get; set; }
        public string? Password { get; set; }
    }
}
