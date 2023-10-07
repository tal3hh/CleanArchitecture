using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Dtos.FoodImages;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.FoodImages
{
    public class GetFoodImagesQueryHandler : IRequestHandler<GetFoodImagesQueryRequest, List<FoodImageDto>>
    {
        private readonly IRepository<FoodImage> _repo;
        private readonly IMapper _mapper;
        public GetFoodImagesQueryHandler(IRepository<FoodImage> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<FoodImageDto>> Handle(GetFoodImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _repo.AllIncludeAsync(x => x.Food, x => x.Id, false);

            return _mapper.Map<List<FoodImageDto>>(list);
        }
    }
}
