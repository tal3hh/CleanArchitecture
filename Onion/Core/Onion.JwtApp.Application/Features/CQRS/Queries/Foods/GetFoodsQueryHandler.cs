using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Dtos.Foods;
using Onion.JwtApp.Application.Features.CQRS.Queries.Category;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Foods
{
    public class GetFoodsQueryHandler : IRequestHandler<GetFoodsQueryRequest, List<FoodDto>>
    {
        private readonly IRepository<Food> _repo;
        private readonly IMapper _mapper;

        public GetFoodsQueryHandler(IRepository<Food> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<FoodDto>> Handle(GetFoodsQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _repo.AllIncludeAsync(x => x.Category,x => x.Id, false);

            return _mapper.Map<List<FoodDto>>(list);
        }
    }
}