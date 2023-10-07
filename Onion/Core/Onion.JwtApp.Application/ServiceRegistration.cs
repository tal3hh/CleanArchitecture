using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
        public static void AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            // Extensions
            service.AddValidation();

            //service.AddTransient<ITokenService, TokenService>();

            service.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
            service.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new Mapping()
                });
            });

            service.AddFluentValidationAutoValidation();

            #region JWT
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audince"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),

                    ClockSkew = TimeSpan.Zero  // remove delay of token when expire
                };
            });

            #endregion

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
