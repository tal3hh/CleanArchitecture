using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Services.Interface;
using System.Text;

namespace Onion.JwtApp.WebApp.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class CategoryController : Controller
	{
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

			var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;

			var response = await _categoryService.CreateAsync(dto,token);
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

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> Update(int id)
		{
			var dto = await _categoryService.GetById(id);

			if (dto != null)
			{
				return View(dto);
			}
			else
			{
				TempData["Warning"] = "Data tapilmadi.";
				return RedirectToAction("List", "Category", new { area = "AdminPanel" });
			}

		}

		[Authorize(Roles = "SuperAdmin")]
		[HttpPost]
		public async Task<IActionResult> Update(CategoryDto dto)
		{
			if (!ModelState.IsValid) return View(dto);

			var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;
			var response = await _categoryService.UpdateAsync(dto,token);

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

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> Delete(int id)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "RestorantToken")?.Value;
			var response = await _categoryService.RemoveAsync(id,token);

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
