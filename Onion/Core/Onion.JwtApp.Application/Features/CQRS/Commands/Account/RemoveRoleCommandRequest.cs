using MediatR;
using Onion.JwtApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class RemoveRoleCommandRequest : IRequest<IResponse>
    {
        public string? Name { get; set; }
        public RemoveRoleCommandRequest(string name)
        {
            Name = name;  
        }
    }
}
