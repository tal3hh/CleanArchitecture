using MediatR;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Foods
{
    public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommandRequest,IResponse>
    {
        private readonly IRepository<Food> _repo;

        public RemoveFoodCommandHandler(IRepository<Food> repo)
        {
            _repo = repo;
        }

        public async Task<IResponse> Handle(RemoveFoodCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(request.Id);

            if (entity != null)
            {
                await _repo.Remove(entity);
                return new Response("200","Entity remove");
            }

            return new Response("404", "Entity not found");
        }
    }
}
