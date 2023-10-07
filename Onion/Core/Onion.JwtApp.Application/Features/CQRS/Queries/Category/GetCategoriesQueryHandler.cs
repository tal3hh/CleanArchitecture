using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Category
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryDto>>
    {
        private readonly IRepository<Onion.JwtApp.Domain.Entities.Category> _repo;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<Onion.JwtApp.Domain.Entities.Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _repo.AllOrderByAsync(x => x.Id, false);

            return _mapper.Map<List<CategoryDto>>(list);
        }
    }
}
