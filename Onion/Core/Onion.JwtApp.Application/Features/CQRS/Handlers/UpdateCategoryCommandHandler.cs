using MediatR;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;


namespace Onion.JwtApp.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repo;

        public UpdateCategoryCommandHandler(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var unchange = await _repo.FindAsync(request.Id);

            if (unchange != null)
            {
                var entity = new Category
                {
                    Id = request.Id,
                    Name = request.Name,
                };

                await _repo.Update(entity, unchange);
            }
        }
    }
}
