
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RBAC.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Presistence
{
    public class RbacContext : IdentityDbContext<IdentityUser>
    {
        public IConfiguration configuration
        {
            get
            {
                var configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            }
        }

        public RbacContext(DbContextOptions<RbacContext> options) 
        : base(options) 
        {
        }
        public RbacContext() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }
        private static void SeedRoles(ModelBuilder builder)
        {
            
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "User", ConcurrencyStamp = "1", NormalizedName = "User" },
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "developer", ConcurrencyStamp = "1", NormalizedName = "developer" },
                new IdentityRole() { Name = "tester", ConcurrencyStamp = "1", NormalizedName = "tester" }

                );
        }

        public DbSet<Product>  Products { get; set; }
        public DbSet<ProductRole> ProductRoles { get; set; }



    }
}
