using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages;
using Onion.JwtApp.Application.Features.CQRS.Queries.FoodImages;

namespace Onion.JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodImageController : ControllerBase
    {
        readonly IMediator _mediator;

        public FoodImageController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetFoodImagesQueryRequest());

            return Ok(result);
        }

		//[Authorize(Roles = "SuperAdmin,Admin")]
		[HttpPost("Multi/{foodid}")]
        public async Task<IActionResult> Create(int foodid, IFormFileCollection photos)
        {
            if(photos.Count() == 0) return BadRequest("Sekil secin");

            var request = new CreateFoodImageCommandRequest
            {
                FoodId = foodid,
                Photos = photos
            };

            var response = await _mediator.Send(request);

            return Ok(response);
        }

		//[Authorize(Roles = "SuperAdmin")]
		[HttpPut]
        public async Task<IActionResult> Update(IFormFile photo, int id)
        {
            var request = new UpdateFoodImageCommandRequest
            {
                Id = id,
                Photo = photo
            };

            var response = await _mediator.Send(request);

            return Ok(response);
        }

		//[Authorize(Roles = "SuperAdmin")]
		[HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _mediator.Send(new RemoveFoodImageCommandRequest(id));

            return Ok(response);
        }

		//[Authorize(Roles = "SuperAdmin")]
		[HttpDelete("Multi/{FoodId}")]
        public async Task<IActionResult> AllRemove(int FoodId)
        {
            var response = await _mediator.Send(new RemoveFoodImagesCommandRequest(FoodId));

            return Ok(response);
        }
    }
}
