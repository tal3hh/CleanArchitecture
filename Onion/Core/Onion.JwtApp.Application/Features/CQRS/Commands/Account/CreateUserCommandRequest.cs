using MediatR;
using Onion.JwtApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class CreateUserCommandRequest : IRequest<IResponse>
    {
        public string? Fullname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfrimPassword { get; set; }
    }
}
