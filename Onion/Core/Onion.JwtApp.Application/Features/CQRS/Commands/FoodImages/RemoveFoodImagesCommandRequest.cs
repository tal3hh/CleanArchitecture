using MediatR;
using Onion.JwtApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class RemoveFoodImagesCommandRequest : IRequest<IResponse>
    {
        public int FoodId { get; set; }
        public RemoveFoodImagesCommandRequest(int Foodid)
        {
            FoodId = Foodid;
        }
    }
}
