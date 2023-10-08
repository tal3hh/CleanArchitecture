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
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest>
    {
        private readonly UserManager<AppUser> _userManager;

        public RemoveUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.IdorEmail != null)
            {
                var user = new AppUser();

                user = await _userManager.FindByEmailAsync(request.IdorEmail);
                if (user == null) 
                    user = await _userManager.FindByIdAsync(request.IdorEmail);

                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }

            }
        }
    }
}
