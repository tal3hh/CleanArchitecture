using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Foods
{
    public class RemoveFoodCommandRequest : IRequest
    {
        public int Id { get; set; }
        public RemoveFoodCommandRequest(int id)
        {
            Id = id;
        }
    }
}
