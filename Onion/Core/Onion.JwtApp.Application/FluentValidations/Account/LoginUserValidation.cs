using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Account
{
    public class LoginUserValidation : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.EmailorUsername).NotNull().WithMessage("EmailorUsername yazin...").Length(3, 50).WithMessage("3-50 intervalinda simvol yazin.");

            RuleFor(x => x.Password).NotNull().WithMessage("Password daxil edin...").Length(3, 80).WithMessage("3-80 intervalinda simvol yazin.");
        }
    }
}
