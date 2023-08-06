using AutoMapper;
using MediatR;
using RBAC.Application.Services;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Features.Commands.CreateEvent
{
    public class RegisterUserRequest : IRequest<AuthenticationResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserRequest, AuthenticationResponse>
    {
        private readonly IUserService _userService;
        public RegisterUserCommandHandler(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<AuthenticationResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterUser(request);
            
        }
    }
}
