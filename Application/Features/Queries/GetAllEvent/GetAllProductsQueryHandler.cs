using AutoMapper;
using MediatR;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Features.Queries.GetAllEvent
{

    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>> { }
    public class GetAllProductsQueryResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IMapper mapper,IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products =  _productRepository.GetAll();
            return _mapper.Map<List<GetAllProductsQueryResponse>>(products);
        }
    }
}
