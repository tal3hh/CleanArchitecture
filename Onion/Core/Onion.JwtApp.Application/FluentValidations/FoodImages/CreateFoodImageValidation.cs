using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.FoodImages
{
    public class CreateFoodImageValidation : AbstractValidator<CreateFoodImageCommandRequest>
    {
        public CreateFoodImageValidation()
        {
            RuleFor(x => x.FoodId).Must(x => x != 0).WithMessage("Id daxil edin.");
            RuleFor(x => x.Photos).Must(x => x.Count() != 0).WithMessage("Sekil secin.");

            //RuleFor(x => x.Photos).NotNull().WithMessage("Sekil secin.").NotEmpty().WithMessage("Sekil secin.");
        }
    }
}
