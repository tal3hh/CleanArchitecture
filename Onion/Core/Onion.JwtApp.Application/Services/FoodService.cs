using Newtonsoft.Json;
using Onion.JwtApp.Application.Dtos.Foods;
using Onion.JwtApp.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FoodService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<FoodDto>?> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:44823/api/Food");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<FoodDto>>(jsonData);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
