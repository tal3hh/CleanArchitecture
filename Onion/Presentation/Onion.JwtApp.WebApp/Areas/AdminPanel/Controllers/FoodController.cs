using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Services.Interface;

namespace Onion.JwtApp.WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodservice;

        public FoodController(IFoodService foodservice)
        {
            _foodservice = foodservice;
        }

        public async Task<IActionResult> List()
        {
            var result = await _foodservice.GetAllAsync();

            return View(result);
        }
    }
}
