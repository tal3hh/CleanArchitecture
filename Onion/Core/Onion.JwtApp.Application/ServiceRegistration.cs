using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.AutoMapper;
using Onion.JwtApp.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service)
        {
            // Extensions
            service.AddValidation();


            service.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
            service.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new Mapping()
                });
            });
            service.AddFluentValidationAutoValidation();
        }
    }
}
