using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.JwtApp.Application.Services.Interface;
using System.Diagnostics;

namespace Onion.JwtApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodService _foodservice;
        private readonly ICategoryService _categoryservice;
        public HomeController(IFoodService foodservice, ICategoryService categoryservice)
        {
            _foodservice = foodservice;
            _categoryservice = categoryservice;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _foodservice.GetAllAsync();
            var categories = await _categoryservice.GetAllAsync();
            return View((foods,categories));
        }
    }
}