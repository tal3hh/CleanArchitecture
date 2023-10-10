using FluentValidation;
using Onion.JwtApp.Application.Dtos.Category;

namespace Onion.JwtApp.Application.FluentValidations.Category
{
    public class CreateCategoryDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CreateCategoryDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Not empty").NotNull().WithMessage("Not null").Length(2, 100).WithMessage("2-100 simvol");
        }
    }
}
