using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Onion.JwtApp.WebApp.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}