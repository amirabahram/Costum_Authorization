using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RBAC.Presistence.Authorization
{
    public class ProductCreatorOrRoleRequirement : IAuthorizationRequirement
    {

    }

    public class ProductCreatorOrRoleRequirementHandler : AuthorizationHandler<ProductCreatorOrRoleRequirement>
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userServise;
        public ProductCreatorOrRoleRequirementHandler(IProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _userServise = userService;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ProductCreatorOrRoleRequirement requirement)
        {

            if (!context.User.Identities.Any(c => c.IsAuthenticated == true))//if user is logged in or not
            {
                context.Fail();
                return Task.CompletedTask;
            }


            var bodyStr = "";
            var req = _httpContextAccessor.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            req.EnableBuffering();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEndAsync().GetAwaiter().GetResult();
            }

            // Rewind, so the core is not lost when it looks at the body for the request
            req.Body.Position = 0;
            // Do whatever works with bodyStr here

            var jsonDocument = JsonDocument.Parse(bodyStr);
            int id = jsonDocument.RootElement.GetProperty("id").GetInt32();


            var manipulatorId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
            string productCreatorId = _productRepository.GetUserIdByProductId(id).GetAwaiter().GetResult();
           var product = _productRepository.Get(id);
            var userRoles = _userServise.GetUserRoles(manipulatorId).GetAwaiter().GetResult();
            if (productCreatorId == manipulatorId)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            foreach ( var role in userRoles )
            {
                if(role.Name.Equals(product.PermittedRole))  context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}


