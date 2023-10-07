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
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommandRequest>
    {
        private readonly IRepository<Food> _repo;

        public UpdateFoodCommandHandler(IRepository<Food> repo)
        {
            _repo = repo;
        }
        public async Task Handle(UpdateFoodCommandRequest request, CancellationToken cancellationToken)
        {
            var unchange = await _repo.FindAsync(request.Id);

            if (unchange != null)
            {
                var entity = new Food
                {
                    Id = request.Id,
                    Name = request.Name,
                    Definition = request.Definition,
                    Price = request.Price,
                    CategoryId = request.CategoryId
                };

                await _repo.Update(entity, unchange);
            }
        }
    }
}
