using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class UpdateFoodImageCommandRequest : IRequest
    {
        public int Id { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
