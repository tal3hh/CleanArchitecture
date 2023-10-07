using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class CreateFoodImageCommandRequest : IRequest
    {
        public int FoodId { get; set; }
        public IFormFileCollection? Photos { get; set; }
    }
}
