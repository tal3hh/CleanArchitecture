using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Onion.JwtApp.Application.Dtos.Category;
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
        private readonly IWebHostEnvironment _env;

        public FoodService(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            _env = env;
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

        public async Task<HttpResponseMessage> CreateAsync(FoodCreateDto dto, string token)
        {
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:44823/api/Food", content);

            return responseMessage;
        }

        //public async Task<HttpResponseMessage?> ImageCreate(IFormFileCollection photos, int foodid)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    foreach (var photo in photos)
        //    {
        //        if (photo.ContentType.Contains("image/"))
        //        {
        //            //string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
        //            //string path = Path.Combine(_env.WebRootPath, "FoodImages", fileName);

        //            //using (FileStream stream = new FileStream(path, FileMode.Create))
        //            //{
        //            //    await photo.CopyToAsync(stream);
        //            //}

        //            var stream = new MemoryStream();
        //            await photo.CopyToAsync(stream);
        //            var bytes = stream.ToArray();

        //            var content = new ByteArrayContent(bytes);
        //            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(photo.ContentType);
        //            var formdata = new MultipartFormDataContent();

        //            formdata.Add(content, "photos", photo.FileName);

        //            var responseMessage = await client.PostAsync($"http://localhost:44823/api/FoodImage/Multi/{foodid}", formdata);

        //            return responseMessage;
        //        }
        //    }

        //    return null;
        //}

        public async Task<FoodUpdateDto?> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:44823/api/Food/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<FoodUpdateDto>(jsonData);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> UpdateAsync(FoodUpdateDto dto, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:44823/api/Food", content);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> RemoveAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.DeleteAsync($"http://localhost:44823/api/Food/{id}");

            return responseMessage;
        }



    }
}
