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
    public class CreateFoodImageCommandHandler : IRequestHandler<CreateFoodImageCommandRequest>
    {
        private readonly IRepository<FoodImage> _repo;
        private readonly IRepository<Food> _repoFood;
        private readonly IWebHostEnvironment _env;

        public CreateFoodImageCommandHandler(IRepository<FoodImage> repo, IWebHostEnvironment env, IRepository<Food> repoFood)
        {
            _repo = repo;
            _env = env;
            _repoFood = repoFood;
        }

        public async Task Handle(CreateFoodImageCommandRequest request, CancellationToken cancellationToken)
        {
            var Food = await _repoFood.FindAsync(request.FoodId);

            if (Food != null && request.Photos != null)
            {
                foreach (var photo in request.Photos)
                {
                    if (photo.ContentType.Contains("image/"))
                    {
                        string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string path = Path.Combine(_env.WebRootPath, "FoodImages", fileName);

                        using (FileStream stream = new FileStream(path, FileMode.Create))
                        {
                            await photo.CopyToAsync(stream);
                        }

                        var FoodImage = new FoodImage
                        {
                            Image = fileName,
                            FoodId = request.FoodId
                        };


                        await _repo.CreateAsync(FoodImage);
                    }
                }
            }

        }
    }
}

