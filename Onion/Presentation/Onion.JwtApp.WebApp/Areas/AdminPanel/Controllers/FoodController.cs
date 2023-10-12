using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Dtos.FoodImages;
using Onion.JwtApp.Application.Dtos.Foods;
using Onion.JwtApp.Application.Services;
using Onion.JwtApp.Application.Services.Interface;

namespace Onion.JwtApp.WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodservice;
        private readonly ICategoryService _categoryService;

        public FoodController(IFoodService foodservice, ICategoryService categoryService)
        {
            _foodservice = foodservice;
            _categoryService = categoryService;
        }

        #region List
        public async Task<IActionResult> List()
        {
            var result = await _foodservice.GetAllAsync();

            return View(result);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();

            return View((new FoodCreateDto(), categories));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] FoodCreateDto dto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;
            var categories = await _categoryService.GetAllAsync();

            if (!ModelState.IsValid) return View((dto, categories));

            var response = await _foodservice.CreateAsync(dto, token);
            if (response.IsSuccessStatusCode)
            {
                TempData["Create"] = "Data elave edildi.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
            else
            {
                TempData["Warning"] = "Data elave etmek ugursuz oldu.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
        }
        #endregion

        #region Update
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var dto = await _foodservice.GetById(id);

            if (dto != null)
            {
                return View((dto, categories));
            }
            else
            {
                TempData["Warning"] = "Data tapilmadi.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }

        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] FoodUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;
            var response = await _foodservice.UpdateAsync(dto, token);

            if (response.IsSuccessStatusCode)
            {
                TempData["Warning"] = "Data yenilendi.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
            else
            {
                TempData["Warning"] = "Update ugursuz oldu.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
        }
        #endregion

        #region Remove
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;
            var response = await _foodservice.RemoveAsync(id, token);

            if (response.IsSuccessStatusCode)
            {
                TempData["Delete"] = "Data silindi.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
            else
            {
                TempData["Warning"] = "Silme ugursuz oldu.";
                return RedirectToAction("List", "Food", new { area = "AdminPanel" });
            }
        }
        #endregion
    }
}
