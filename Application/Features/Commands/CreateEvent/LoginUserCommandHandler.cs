using MediatR;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Features.Commands.CreateEvent
{
    public class LoginUserCommandRequest : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, AuthenticationResponse>
    {
        private readonly IUserService _userService;
        public LoginUserCommandHandler(IUserService userService) => _userService = userService;

        public async  Task<AuthenticationResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.LoginUser(request);
        }
    }
}
