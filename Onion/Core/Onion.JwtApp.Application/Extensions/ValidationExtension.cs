using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.Features.CQRS.Commands.Category;
using Onion.JwtApp.Application.Features.CQRS.Commands.FoodImages;
using Onion.JwtApp.Application.Features.CQRS.Commands.Foods;
using Onion.JwtApp.Application.FluentValidations.Category;
using Onion.JwtApp.Application.FluentValidations.FoodImages;
using Onion.JwtApp.Application.FluentValidations.Foods;
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

            services.AddScoped<IValidator<CreateFoodCommandRequest>, CreateFoodValidation>();
            services.AddScoped<IValidator<UpdateFoodCommandRequest>, UpdateFoodValidation>();

            services.AddScoped<IValidator<CreateFoodImageCommandRequest>, CreateFoodImageValidation>();
        }
    }
}
