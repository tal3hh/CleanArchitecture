using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Persistance.Contexts;
using Onion.JwtApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(configuration["ConnectionStrings:Postgresql"]);
            });

            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
