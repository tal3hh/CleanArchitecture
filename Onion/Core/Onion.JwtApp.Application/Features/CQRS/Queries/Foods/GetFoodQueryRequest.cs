using MediatR;
using Onion.JwtApp.Application.Dtos.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Foods
{
    public class GetFoodQueryRequest : IRequest<FoodDto>
    {
        public int Id { get; set; }
        public GetFoodQueryRequest(int id)
        {
            Id = id;
        }
    }
}
