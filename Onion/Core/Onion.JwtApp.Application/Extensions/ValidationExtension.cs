using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.Features.CQRS.Commands;
using Onion.JwtApp.Application.FluentValidations.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Extensions
{
    public static class ValidationExtension
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCategoryCommandRequest>, CreateCategoryValidation>();
            services.AddScoped<IValidator<UpdateCategoryCommandRequest>, UpdateCategoryValidation>();
        }
    }
}
