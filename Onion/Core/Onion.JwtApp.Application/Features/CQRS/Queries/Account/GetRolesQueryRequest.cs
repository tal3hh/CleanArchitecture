using MediatR;
using Onion.JwtApp.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Account
{
    public class GetRolesQueryRequest : IRequest<List<RoleDto>>
    {
    }
}
