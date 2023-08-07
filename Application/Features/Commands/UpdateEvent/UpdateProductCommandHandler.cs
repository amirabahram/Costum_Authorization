using AutoMapper;
using MediatR;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.Entities.Common;
using RBAC.Domain.Entities.Products;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RBAC.Domain.Entities.Products.AppResponse;

namespace RBAC.Application.Features.Commands.UpdateEvent
{
    public class UpdateProductCommandRequest : IRequest<AppResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, AppResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUserService _userService;
        private readonly IProductRolesRepository _permittedRolesRepository;

        public UpdateProductCommandHandler(IMapper mapper,
            IProductRepository productRepository,
            IUserService userService,
            IProductRolesRepository permittedRolesRepository)
        {
            this._mapper = mapper;  
            this._productRepository = productRepository;
            this._userService = userService;
            this._permittedRolesRepository = permittedRolesRepository;
        }
        public async Task<AppResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //var product = _mapper.Map<Product>(request);
            var userId = await _userService.GetUserId();
            var product = new Product()
            {
                Title = request.Title,
                UserId = userId,
                Id = request.Id
            };
            _productRepository.Update(product);
           
            return new SuccessResponse(ResultMessages.UPDATED_PRODUCT_SUCCESSFULLY);

        }
    }
}
