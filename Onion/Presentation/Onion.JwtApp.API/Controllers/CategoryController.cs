using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Features.CQRS.Queries;

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _mediatr.Send(request);

            return Ok("Created data...");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _mediatr.Send(request);

            return Ok("Updated data...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediatr.Send(new RemoveCategoryCommandRequest(id));

            return Ok("Removed data...");
        }


        [HttpPost]
        public async Task<IActionResult> Upload(int id,IFormFile file)
        {
            return Ok();
        }
    }
}
