using MediatR;
using Microsoft.AspNetCore.Identity;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Application.Dtos.Account;
using Onion.JwtApp.Application.Services.Interface;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,TokenResponseDto?>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

		public async Task<TokenResponseDto?> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{

			if (request.EmailorUsername != null)
			{
				var user = new AppUser();

				user = await _userManager.FindByEmailAsync(request.EmailorUsername);
				if (user == null)
					user = await _userManager.FindByNameAsync(request.EmailorUsername);

				if (user != null && request.Password != null && user.UserName != null)
				{
					if (await _userManager.CheckPasswordAsync(user, request.Password))
					{
						var roles = await _userManager.GetRolesAsync(user);

						var token = _tokenService.GenerateJwtToken(user.UserName, (List<string>)roles);

						return token;
					}

					//throw new UnauthorizedAccessException();
				}

				//throw new NullReferenceException();
			}

			return new TokenResponseDto("null", DateTime.Now);
		}
	}
}
