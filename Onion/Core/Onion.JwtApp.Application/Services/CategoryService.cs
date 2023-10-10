using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryService(IHttpClientFactory httpClientFactory )
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<CategoryDto>?> GetAllAsync()
        {
            var clinet = _httpClientFactory.CreateClient();

            var responseMessage = await clinet.GetAsync("http://localhost:44823/api/Category");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CategoryDto>>(jsondata);

                return result;
            }
            else
            {
                return null;
            }
        }


        public async Task<HttpResponseMessage> CreateAsync(CategoryCreateDto dto)
        {
            var clinet = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await clinet.PostAsync("http://localhost:44823/api/Category", content);

            return responseMessage;
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:44823/api/Category/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<CategoryDto>(jsonData);
                return dto;
            }
            else
            {
                return null;
            }

        }

        public async Task<HttpResponseMessage> UpdateAsync(CategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:44823/api/Category", content);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> RemoveAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"http://localhost:44823/api/Category/{id}");

            return responseMessage;
        }
    }
}
