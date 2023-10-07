using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Category
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryDto?>
    {
        private readonly IRepository<Onion.JwtApp.Domain.Entities.Category> _repo;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Onion.JwtApp.Domain.Entities.Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategoryDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(request.Id);

            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
