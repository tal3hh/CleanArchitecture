using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.JwtApp.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Account
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, List<RoleDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return _mapper.Map<List<RoleDto>>(roles);
        }
    }
}
