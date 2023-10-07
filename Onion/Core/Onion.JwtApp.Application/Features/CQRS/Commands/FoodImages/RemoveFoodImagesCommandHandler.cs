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
    public class RemoveFoodImagesCommandHandler : IRequestHandler<RemoveFoodImagesCommandRequest>
    {
        private readonly IRepository<FoodImage> _repo;
        private readonly IWebHostEnvironment _env;

        public RemoveFoodImagesCommandHandler(IRepository<FoodImage> repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public async Task Handle(RemoveFoodImagesCommandRequest request, CancellationToken cancellationToken)
        {
            var list = await _repo.AllFilterAsync(x => x.FoodId == request.FoodId);

            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var path = Path.Combine(_env.WebRootPath, "FoodImages", item.Image);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    await _repo.Remove(item);
                }
            }
        }
    }
}
