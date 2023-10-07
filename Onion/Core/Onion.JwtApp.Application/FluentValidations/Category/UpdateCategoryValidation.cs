using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Category
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x => x.Id).Must(x => x != 0).WithMessage("Id daxil edin.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .Length(2, 100).WithMessage("2-100 simvol");
        }
    }
}
