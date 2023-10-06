using Microsoft.EntityFrameworkCore;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasOne(x => x.Category).WithMany(x => x.Foods).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<FoodImage>().HasOne(x => x.Food).WithMany(x => x.FoodImages).HasForeignKey(x => x.FoodId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodImage> foodImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
