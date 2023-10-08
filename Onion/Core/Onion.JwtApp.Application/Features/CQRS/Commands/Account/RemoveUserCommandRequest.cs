using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class RemoveUserCommandRequest : IRequest
    {
        public string? IdorEmail { get; set; }
        public RemoveUserCommandRequest(string? idoremail)
        {
            IdorEmail = idoremail;
        }
    }
}
