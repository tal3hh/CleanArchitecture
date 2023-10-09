using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal.TypeHandlers.FullTextSearchHandlers;
using Onion.JwtApp.Application.Features.CQRS.Commands.Account;
using Onion.JwtApp.Application.Features.CQRS.Queries.Account;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            if(!ModelState.IsValid) return BadRequest();

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> AllUsers()
        {
            var list = await _mediator.Send(new GetUsersQueryRequest());

            return Ok(list);
        }

        [HttpDelete("User/{IdorEmail}")]
        public async Task<IActionResult> UserDelete(string IdorEmail)
        {
            var response = await _mediator.Send(new RemoveUserCommandRequest(IdorEmail));

            return Ok(response);
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> AllRoles()
        {
            var list = await _mediator.Send(new GetRolesQueryRequest());

            return Ok(list);
        }

        [Authorize]
        [HttpPost("Role")]
        public async Task<IActionResult> CreateRole(CreateRoleCommandRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _mediator.Send(request);

            return Ok();
        }

        [Authorize]
        [HttpDelete("Role/{name}")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            var response = await _mediator.Send(new RemoveRoleCommandRequest(name));

            return Ok(response);
        }
    }
}
