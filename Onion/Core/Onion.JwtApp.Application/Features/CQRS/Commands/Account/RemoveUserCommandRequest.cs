using MediatR;
using Onion.JwtApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class RemoveUserCommandRequest : IRequest<IResponse>
    {
        public string? IdorEmail { get; set; }
        public RemoveUserCommandRequest(string? idoremail)
        {
            IdorEmail = idoremail;
        }
    }
}
