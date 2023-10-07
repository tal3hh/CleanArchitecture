using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Foods
{
    public class CreateFoodCommandRequest : IRequest
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Definition { get; set; }

        public int CategoryId { get; set; }
    }
}
