using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = new IdentityRole { Name = request.Name };

            await _roleManager.CreateAsync(role);
        }
    }
}
