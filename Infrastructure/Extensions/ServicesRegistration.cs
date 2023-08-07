using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBAC.Application.Services.Interfaces;
using RBAC.Application.Services.Implementation;
using RBAC.Domain.IRepositories;
using RBAC.Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RBAC.Presistence.Authorization;

namespace RBAC.Presistence.Extensions
{
    public static class ServicesRegistration
    {
        public static void AddPresistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //For Entity Framework

            //services.AddDbContext<RbacContext>(Options =>
            //{
            //    Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //}
            //);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorizationHandler,ProductCreatorOrRoleRequirementHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRolesRepository,ProductRolesRepository>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                
            });
        }

    }
}
