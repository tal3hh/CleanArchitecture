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
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommandRequest>
    {
        private readonly IRepository<Food> _repo;

        public CreateFoodCommandHandler(IRepository<Food> repo)
        {
            _repo = repo;
        }

       public async Task Handle(CreateFoodCommandRequest request, CancellationToken cancellationToken)
       {
           var entity = new Food
           {
               Name = request.Name,
               Definition = request.Definition,
               Price = request.Price,
               CategoryId = request.CategoryId
           };

           await _repo.CreateAsync(entity);
       }
    }
}
