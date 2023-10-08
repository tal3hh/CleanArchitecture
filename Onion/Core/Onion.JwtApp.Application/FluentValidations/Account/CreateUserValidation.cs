using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Account
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Fullname).NotNull().WithMessage("Fullname bos ola bilmez")
                .NotEmpty().WithMessage("Fullname bos ola bilmez")
                .Length(5, 100).WithMessage("5-100 arasi simvol");

            RuleFor(x => x.Username).NotNull().WithMessage("Username bos ola bilmez")
                .NotEmpty().WithMessage("Username bos ola bilmez")
                .Length(3, 50).WithMessage("3-50 arasi simvol");

            RuleFor(x => x.Email).NotNull().WithMessage("Email bos ola bilmez")
                .NotEmpty().WithMessage("Email bos ola bilmez")
                .Length(5, 150).WithMessage("5-150 arasi simvol")
                .EmailAddress().WithMessage("Email(@) formatinda yazi daxil edin.");

            RuleFor(x => x.Password).NotNull().WithMessage("Password daxil edin...")
                .Length(3, 80).WithMessage("3-80 intervalinda simvol yazin.");

            RuleFor(x => x.ConfrimPassword).NotNull().WithMessage("Tekrar sifre daxil edin...")
                .Equal(x => x.Password).WithMessage("Tekrar sifre yalnisdir.")
                .Length(3, 80).WithMessage("3-80 intervalinda simvol yazin."); ;

        }
    }
}
