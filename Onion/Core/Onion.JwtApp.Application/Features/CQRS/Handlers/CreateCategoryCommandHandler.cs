using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repo;
        public CreateCategoryCommandHandler(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Category { Name = request.Name };

            await _repo.CreateAsync(entity);
        }
    }
}
