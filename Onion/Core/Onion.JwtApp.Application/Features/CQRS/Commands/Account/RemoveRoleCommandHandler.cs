using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Account
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommandRequest>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RemoveRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Handle(RemoveRoleCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Name != null)
            {
                var role = await _roleManager.FindByNameAsync(request.Name);

                if (role != null)
                {
                    await _roleManager.DeleteAsync(role);
                }
            }
        }
    }
}
