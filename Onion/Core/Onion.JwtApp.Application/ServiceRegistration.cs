using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Onion.JwtApp.Application.AutoMapper;
using Onion.JwtApp.Application.Extensions;
using Onion.JwtApp.Application.Services;
using Onion.JwtApp.Application.Services.Interface;
using Onion.JwtApp.Domain.Entities;
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
        public static void AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            // Extensions
            service.AddValidation();

            service.AddTransient<ITokenService, TokenService>();

            service.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));

            service.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new Mapping()
                });
            });

            service.AddAuthentication();
            service.AddAuthorization();

            service.AddFluentValidationAutoValidation();

            //AppUserdeki CreateDate=DateTime.Now PostgreSqldeki formatda oturur.(Errorun qarsini almaq ucundur.)
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            

            #region Configure
            service.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "RestorantApp";
                opt.LoginPath = new PathString("/Account/Login");
                //opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
            #endregion
        }
    }
}
