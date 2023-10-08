using FluentValidation;
using Onion.JwtApp.Application.Features.CQRS.Commands.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.FluentValidations.Account
{
    public class CreateRoleValidation : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name bos ola bilmez")
                .NotEmpty().WithMessage("Name bos ola bilmez")
                .Length(2, 100).WithMessage("2-100 arasi simvol");
        }
    }
}
