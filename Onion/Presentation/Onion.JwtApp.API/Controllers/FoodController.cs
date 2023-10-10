using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands.Category;
using Onion.JwtApp.Application.Features.CQRS.Commands.Foods;
using Onion.JwtApp.Application.Features.CQRS.Queries.Foods;

namespace Onion.JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetFoodsQueryRequest());

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFoodQueryRequest(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodCommandRequest request)
        {
            if(!ModelState.IsValid) return BadRequest();

            await _mediator.Send(request);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFoodCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = await _mediator.Send(request);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _mediator.Send(new RemoveFoodCommandRequest(id));

            return Ok(response);
        }
    }
}
