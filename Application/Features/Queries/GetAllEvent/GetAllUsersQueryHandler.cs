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
        public List<string> Roles { get; set; }
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public GetAllUsersQueryHandler(IUserRepository userRepository,UserManager<IdentityUser> userManager)
        {
            this._userRepository = userRepository;
            this._userManager = userManager;
        }
        public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
           var users = await _userRepository.GetAllUsers();
            var responses = new List<GetAllUsersQueryResponse>();
            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var response = new GetAllUsersQueryResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    Roles = roles as List<string>
                };
                responses.Add(response);
            }
            return responses;
        }
    }
}
