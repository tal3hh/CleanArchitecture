using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Dtos.Foods;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Foods
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQueryRequest, FoodDto>
    {
        private readonly IRepository<Food> _repo;
        private readonly IMapper _mapper;

        public GetFoodQueryHandler(IRepository<Food> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<FoodDto> Handle(GetFoodQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.SingleOrDefaultAsync(x => x.Category, x => x.Id == request.Id);

            if (entity != null)
            {
                return _mapper.Map<FoodDto>(entity);
            }

            throw new NullReferenceException();
        }
    }
}
