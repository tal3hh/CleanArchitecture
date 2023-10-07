using MediatR;
using Onion.JwtApp.Application.Dtos.Category;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.Category
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryDto>>
    {
    }
}
