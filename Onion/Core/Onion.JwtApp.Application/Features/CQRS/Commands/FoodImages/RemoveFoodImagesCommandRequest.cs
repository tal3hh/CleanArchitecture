using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class RemoveFoodImagesCommandRequest : IRequest
    {
        public int FoodId { get; set; }
        public RemoveFoodImagesCommandRequest(int Foodid)
        {
            FoodId = Foodid;
        }
    }
}
