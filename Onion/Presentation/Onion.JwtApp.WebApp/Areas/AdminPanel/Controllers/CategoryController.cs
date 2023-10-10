using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Services.Interface;
using System.Text;

namespace Onion.JwtApp.WebApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> List()
        {
            var result = await _categoryService.GetAllAsync();

            return View(result);
        }


       public IActionResult Create()
       {
           return View(new CategoryCreateDto());
       }
       [HttpPost]
       public async Task<IActionResult> Create(CategoryCreateDto dto)
       {
           if (!ModelState.IsValid) return View(dto);


           var response = await _categoryService.CreateAsync(dto);
           if (response.IsSuccessStatusCode)
           {
               TempData["Create"] = "Data elave edildi.";
               return RedirectToAction("List", "Category", new { area = "AdminPanel" });
           }
           else
           {
               TempData["Warning"] = "Data elave etmek ugursuz oldu.";
               return RedirectToAction("List", "Category", new { area = "AdminPanel" });
           }
       }


       public async Task<IActionResult> Update(int id)
       {
            var dto = await _categoryService.GetById(id);

            if(dto != null)
            {
                return View(dto);
            }
            else
            {
                TempData["Warning"] = "Data tapilmadi.";
                return RedirectToAction("List", "Category", new { area = "AdminPanel" });
            }

        }
       [HttpPost]
       public async Task<IActionResult> Update(CategoryDto dto)
       {
           if (!ModelState.IsValid) return View(dto);

            var response = await _categoryService.UpdateAsync(dto);

           if (response.IsSuccessStatusCode)
           {
               TempData["Warning"] = "Data yenilendi.";
               return RedirectToAction("List", "Category", new { area = "AdminPanel" });
           }
           else
           {
               TempData["Warning"] = "Update ugursuz oldu.";
               return RedirectToAction("List", "Category", new { area = "AdminPanel" });
           }
       }


        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.RemoveAsync(id);

            if (response.IsSuccessStatusCode)
            {
                TempData["Delete"] = "Data silindi.";
                return RedirectToAction("List", "Category", new { area = "AdminPanel" });
            }
            else
            {
                TempData["Warning"] = "Silme ugursuz oldu.";
                return RedirectToAction("List", "Category", new { area = "AdminPanel" });
            }

        }
    }
}
