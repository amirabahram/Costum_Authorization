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

namespace RBAC.Application.Features.Commands.CreateEvent
{
    public class CreateProductCommandRequest : IRequest<AppResponse>
    {
        public string Title { get; set; }
        public string PermittedRole { get; set; }
        public CreateProductCommandRequest(string title, string permittedRole)
        {
            this.Title = title;
            this.PermittedRole = permittedRole;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, AppResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _prductRepository;
        private readonly IUserService _userService;


        public CreateProductCommandHandler(IMapper mapper,
            IProductRepository prductRepository,
            IUserService userService)
        {
            _mapper = mapper;
            _prductRepository = prductRepository;
            _userService = userService;
        }




        public async Task<AppResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var userId = await _userService.GetUserId();
            product.UserId = userId;
            _prductRepository.Add(product);
            return await Task.FromResult<AppResponse>(new SuccessResponse(ResultMessages.CREATED_PRODUCT_SUCCESSFULLY));
        }
    }
}
