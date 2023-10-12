using Onion.JwtApp.Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>?> GetAllAsync();

		Task<HttpResponseMessage> CreateAsync(CategoryCreateDto dto, string token);
        Task<CategoryDto?> GetById(int id);
        Task<HttpResponseMessage> UpdateAsync(CategoryDto dto, string token);
        Task<HttpResponseMessage> RemoveAsync(int id, string token);
    }
}
