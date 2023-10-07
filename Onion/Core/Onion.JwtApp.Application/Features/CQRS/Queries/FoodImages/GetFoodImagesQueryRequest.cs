using MediatR;
using Onion.JwtApp.Application.Dtos.FoodImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.FoodImages
{
    public class GetFoodImagesQueryRequest : IRequest<List<FoodImageDto>>
    {
    }
}
