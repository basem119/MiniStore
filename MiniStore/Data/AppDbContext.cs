using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MiniStore.Models.Entities;

namespace MiniStore.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice
            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "Admin",
            //        NormalizedName = "admin",
            //        ConcurrencyStamp = Guid.NewGuid().ToString(),
            //    },
            //    new IdentityRole()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "User",
            //        NormalizedName = "user",
            //        ConcurrencyStamp = Guid.NewGuid().ToString(),
            //    });
            base.OnModelCreating(modelBuilder);

           modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
