using FluentValidation;
using FluentValidation.Validators;
using Onion.JwtApp.Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Category
{
    public class UpdateCategoryDtoValidation : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .Length(2, 100).WithMessage("2-100 simvol");
        }
    }
}
