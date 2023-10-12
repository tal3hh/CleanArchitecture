using MediatR;
using Microsoft.AspNetCore.Hosting;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class CreateFoodImageCommandHandler : IRequestHandler<CreateFoodImageCommandRequest,IResponse>
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

        public async Task<IResponse> Handle(CreateFoodImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Photos != null)
            {
                var Food = await _repoFood.FindAsync(request.FoodId);

                if (Food != null)
                {
                    var notimage = 0;
                    foreach (var photo in request.Photos)
                    {
                        if (photo.ContentType.Contains("image/"))
                        {
                            string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                            //string path = Path.Combine(_env.WebRootPath, "FoodImages", fileName);

                            //using (FileStream stream = new FileStream(path, FileMode.Create))
                            //{
                            //    await photo.CopyToAsync(stream);
                            //}

                            var FoodImage = new FoodImage
                            {
                                Image = fileName,
                                FoodId = request.FoodId
                            };

                            await _repo.CreateAsync(FoodImage);
                        }
                        else
                        {
                            notimage++;
                        }
                    }
                    return new Response("200", $"Photo count:{request.Photos.Count()}, Images add: {request.Photos.Count()-notimage}, No image type: {notimage}");
                }
                return new Response("404", "Entity is null");
            }
            return new Response("404", "Photo is null");
        }
    }
}

