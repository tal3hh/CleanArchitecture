using MediatR;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Foods
{
    public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommandRequest>
    {
        private readonly IRepository<Food> _repo;

        public RemoveFoodCommandHandler(IRepository<Food> repo)
        {
            _repo = repo;
        }

        public async Task Handle(RemoveFoodCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(request.Id);

            if (entity != null)
            {
                await _repo.Remove(entity);
            }
        }
    }
}
