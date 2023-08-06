using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RBAC.Application.Features.Commands.CreateEvent;
using RBAC.Application.Features.Commands.DeleteEvent;
using RBAC.Application.Features.Commands.UpdateEvent;
using RBAC.Application.Features.Queries.GetAllEvent;
using RBAC.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile() 
        {
            //Commands
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product,UpdateProductCommandRequest>().ReverseMap();
            CreateMap<IdentityUser,RegisterUserRequest>().ReverseMap();
            

            //Queries
            CreateMap<Product,GetAllProductsQueryResponse>().ReverseMap();
            CreateMap<IdentityUser, GetAllUsersQueryResponse>().ReverseMap();
        }
    }
}
