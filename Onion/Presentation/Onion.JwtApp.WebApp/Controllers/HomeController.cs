using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Onion.JwtApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public HomeController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}


        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}