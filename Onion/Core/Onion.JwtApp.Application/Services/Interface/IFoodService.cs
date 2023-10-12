using Microsoft.AspNetCore.Http;
using Onion.JwtApp.Application.Dtos.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services.Interface
{
    public interface IFoodService
    {
        Task<List<FoodDto>?> GetAllAsync();
        Task<HttpResponseMessage> CreateAsync(FoodCreateDto dto, string token);
        Task<FoodUpdateDto?> GetById(int id);
        Task<HttpResponseMessage> UpdateAsync(FoodUpdateDto dto, string token);
        Task<HttpResponseMessage> RemoveAsync(int id, string token);
        //Task<HttpResponseMessage?> ImageCreate(IFormFileCollection photos, int foodid);

    }

}
