using MediatR;
using Microsoft.AspNetCore.Identity;
using Onion.JwtApp.Application.Common;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,IResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Password == null) return new Response("404", "Password is null");

            var user = new AppUser()
            {
                Fullname = request.Fullname,
                UserName = request.Username,
                Email = request.Email,
            };
            
            var identity = await _userManager.CreateAsync(user, request.Password);

            if (identity.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "SuperAdmin"
                });

                await _userManager.AddToRoleAsync(user, "SuperAdmin");

                return new Response("201","Create user");
            }

            return new Response("404", $"Identity not success");
        }

    }
}
