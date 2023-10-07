using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Foods
{
    public class CreateFoodValidation : AbstractValidator<CreateFoodCommandRequest>
    {
        public CreateFoodValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bos ola bilmez")
                .NotNull().WithMessage("Bos ola bilmez")
                .Length(2, 50).WithMessage("2-50 simvol");

            RuleFor(x=> x.CategoryId).Must(x => x != 0).WithMessage("0 ola bilmez.");
            RuleFor(x=> x.Price).Must(x => x > 0 && x<500).WithMessage("0-500 arasi qiymet");

            RuleFor(x => x.Definition).NotEmpty().WithMessage("Bos ola bilmez")
                .NotNull().WithMessage("Bos ola bilmez")
                .Length(2, 200).WithMessage("2-200 simvol");
        }
    }
}
