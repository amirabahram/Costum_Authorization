using MediatR;
using RBAC.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Features.Commands.CreateEvent
{
    public class AddRoleCommandRequest : IRequest<string>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommandRequest, string>
    {
        private readonly IUserService _userService;
        public AddRoleCommandHandler(IUserService userService)
        {
            this._userService = userService;
        }
        public async Task<string> Handle(AddRoleCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.AddRoleToUser(request.UserId, request.RoleName);
        }
    }
}
