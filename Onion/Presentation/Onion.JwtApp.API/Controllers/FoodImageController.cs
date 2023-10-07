using MediatR;
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

        [HttpPost("Multi")]
        public async Task<IActionResult> Create(IFormFileCollection photos, int FoodId)
        {
            if(photos.Count() == 0) return BadRequest("Sekil secin");

            var request = new CreateFoodImageCommandRequest
            {
                FoodId = FoodId,
                Photos = photos
            };

            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(IFormFile photo, int id)
        {
            if (photo == null) return BadRequest();

            var request = new UpdateFoodImageCommandRequest
            {
                Id = id,
                Photo = photo
            };

            await _mediator.Send(request);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            if (id == 0) return BadRequest();

            await _mediator.Send(new RemoveFoodImageCommandRequest(id));

            return Ok();
        }

        [HttpDelete("Multi/{FoodId}")]
        public async Task<IActionResult> AllRemove(int FoodId)
        {
            if (FoodId == 0) return BadRequest();

            await _mediator.Send(new RemoveFoodImagesCommandRequest(FoodId));

            return Ok();
        }
    }
}
