using AutoMapper;
using MediatR;
using RBAC.Domain.Entities.Common;
using RBAC.Domain.Entities.Products;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RBAC.Domain.Entities.Products.AppResponse;

namespace RBAC.Application.Features.Commands.CreateEvent
{
    public class AddRoleToProductRequest : IRequest<AppResponse>
    {
        public string RoleId { get; set; }
        public int ProductId { get; set; }
    }
    public class AddRoleToProductCommandHandler : IRequestHandler<AddRoleToProductRequest, AppResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRolesRepository _productRolesrepository;
        public AddRoleToProductCommandHandler(IMapper mapper,IProductRolesRepository productRolesRepository)
        {
            this._mapper = mapper;
            this._productRolesrepository = productRolesRepository;
        }
        public async Task<AppResponse> Handle(AddRoleToProductRequest request, CancellationToken cancellationToken)
        {
            var productRole =  _mapper.Map<ProductRole>(request);
            _productRolesrepository.Add(productRole);
            return await Task.FromResult<AppResponse>(new SuccessResponse(ResultMessages.ADDED_ROLE_TO_PRODUCT));
        }
    }

}
