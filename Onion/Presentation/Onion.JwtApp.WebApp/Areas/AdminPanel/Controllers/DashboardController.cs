using Microsoft.AspNetCore.Mvc;

namespace Onion.JwtApp.WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public DashboardController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
