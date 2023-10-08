using MediatR;
using Microsoft.AspNetCore.Identity;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
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
                    Name = "Member"
                });

                await _userManager.AddToRoleAsync(user, "Member");
            }

        }
    }
}
