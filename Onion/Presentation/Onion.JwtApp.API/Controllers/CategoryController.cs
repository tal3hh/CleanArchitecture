using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands.Category;
using Onion.JwtApp.Application.Features.CQRS.Queries.Category;

namespace Onion.JwtApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediatr;

        public CategoryController(IMediator mediatro)
        {
            _mediatr = mediatro;
        }

		[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatr.Send(new GetCategoriesQueryRequest());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediatr.Send(new GetCategoryQueryRequest(id));

            return Ok(result);
        }

		[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _mediatr.Send(request);

            return Ok("Created data...");
        }

		[Authorize(Roles = "SuperAdmin")]
		[HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = await _mediatr.Send(request);

            return Ok(response);
        }

		[Authorize(Roles = "SuperAdmin")]
		[HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response =  await _mediatr.Send(new RemoveCategoryCommandRequest(id));

            return Ok(response);
        }
    }
}
