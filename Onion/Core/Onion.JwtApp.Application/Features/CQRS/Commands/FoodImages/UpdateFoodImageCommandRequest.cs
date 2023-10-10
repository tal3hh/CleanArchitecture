using MediatR;
using Microsoft.AspNetCore.Http;
using Onion.JwtApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class UpdateFoodImageCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
