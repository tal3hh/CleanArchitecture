using MediatR;
using Onion.JwtApp.Application.Interfaces;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Onion.JwtApp.Domain.Entities.Category> _repo;

        public CreateCategoryCommandHandler(IRepository<Onion.JwtApp.Domain.Entities.Category> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Onion.JwtApp.Domain.Entities.Category { Name = request.Name };

            await _repo.CreateAsync(entity);
        }
    }
}
