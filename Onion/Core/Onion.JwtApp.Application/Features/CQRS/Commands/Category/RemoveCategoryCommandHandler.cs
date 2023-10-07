using MediatR;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Category
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Onion.JwtApp.Domain.Entities.Category> _repo;

        public RemoveCategoryCommandHandler(IRepository<Onion.JwtApp.Domain.Entities.Category> repo)
        {
            _repo = repo;
        }

        public async Task Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(request.Id);

            if (entity != null)
            {
                await _repo.Remove(entity);
            }
        }
    }
}
