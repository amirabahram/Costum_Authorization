using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Features.Queries.GetAllEvent
{
    public class GetAllUsersQueryRequest : IRequest<List<GetAllUsersQueryResponse>>{}
    public class GetAllUsersQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository,IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
           var users = await _userRepository.GetAllUsers();
           return _mapper.Map<List<GetAllUsersQueryResponse>>(users);
        }
    }
}
