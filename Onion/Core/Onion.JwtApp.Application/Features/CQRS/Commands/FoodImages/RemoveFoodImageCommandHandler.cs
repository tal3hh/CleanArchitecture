using MediatR;
using Microsoft.AspNetCore.Hosting;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class RemoveFoodImageCommandHandler : IRequestHandler<RemoveFoodImageCommandRequest>
    {
        private readonly IRepository<FoodImage> _repo;
        private readonly IWebHostEnvironment _env;

        public RemoveFoodImageCommandHandler(IRepository<FoodImage> repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public async Task Handle(RemoveFoodImageCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(request.Id);

            if (entity != null)
            {
                var path = Path.Combine(_env.WebRootPath, "FoodImages", entity.Image);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                await _repo.Remove(entity);
            }
        }
    }
}
