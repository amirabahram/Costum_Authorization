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

namespace RBAC.Application.Features.Commands.DeleteEvent
{
    public class DeleteProductCommandRequest : IRequest<AppResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, AppResponse>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
      
            this._productRepository = productRepository;
        }
        public async Task<AppResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            _productRepository.Delete(request.Id);
            return new SuccessResponse(ResultMessages.DELETED_PRODUCT_PERMANENTLY);
        }
    }
}
