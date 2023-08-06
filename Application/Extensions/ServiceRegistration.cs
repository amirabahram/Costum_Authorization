using Microsoft.Extensions.DependencyInjection;
using RBAC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GeneralProfile));
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(  Assembly.GetExecutingAssembly()));


        }
    }
}
