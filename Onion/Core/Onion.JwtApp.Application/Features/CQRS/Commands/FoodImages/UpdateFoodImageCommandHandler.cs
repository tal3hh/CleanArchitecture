using MediatR;
using Microsoft.AspNetCore.Hosting;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages
{
    public class UpdateFoodImageCommandHandler : IRequestHandler<UpdateFoodImageCommandRequest,IResponse>
    {
        private readonly IRepository<FoodImage> _repo;
        private readonly IWebHostEnvironment _env;

        public UpdateFoodImageCommandHandler(IRepository<FoodImage> repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public async Task<IResponse> Handle(UpdateFoodImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Photo != null)
            {
                var unchange = await _repo.FindAsync(request.Id);

                if (unchange != null)
                {
                    string oldpath = Path.Combine(_env.WebRootPath, "FoodImages", unchange.Image);

                    if (File.Exists(oldpath))
                    {
                        File.Delete(oldpath);
                    }
                    else
                    {
                        return new Response("404", "Photo not exists");
                    }

                    string filename = Guid.NewGuid() + "_" + request.Photo.Name;
                    string NewPath = _env.WebRootPath + "FoodImages" + filename;
                    using (FileStream stream = new FileStream(NewPath, FileMode.Create))
                    {
                        await request.Photo.CopyToAsync(stream);
                    }

                    var entity = unchange;
                    entity.Image = filename;

                    await _repo.Update(entity, unchange);
                    return new Response("200", "Image update");
                }
                return new Response("404", "Image not found");
            }
            return new Response("404", "Photo is null");
        }

        //public async Task Handle(UpdateFoodImageCommandRequest request, CancellationToken cancellationToken)
        //{
        //    var unchange = await _repo.FindAsync(request.Id);

        //    if (unchange != null && request.Photo != null)
        //    {
        //        string oldpath = Path.Combine(_env.WebRootPath, "FoodImages", unchange.Image);

        //        if (File.Exists(oldpath))
        //        {
        //            File.Delete(oldpath);
        //        }

        //        string filename = Guid.NewGuid() + "_" + request.Photo.Name;
        //        string NewPath = _env.WebRootPath + "FoodImages" + filename;
        //        using (FileStream stream = new FileStream(NewPath, FileMode.Create))
        //        {
        //            await request.Photo.CopyToAsync(stream);
        //        }

        //        var entity = unchange;
        //        entity.Image = filename;

        //        await _repo.Update(entity, unchange);
        //    }
        //}
    }
}
