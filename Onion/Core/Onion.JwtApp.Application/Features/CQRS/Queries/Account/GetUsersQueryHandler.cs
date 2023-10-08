using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.JwtApp.Application.Dtos.Account;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Account
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<UserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<UserDto>>(list);
        }
    }
}
