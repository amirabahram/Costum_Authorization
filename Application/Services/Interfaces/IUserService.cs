using Microsoft.AspNetCore.Identity;
using RBAC.Application.Features.Commands.CreateEvent;
using RBAC.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(IdentityUser user);
        Task<bool> EmailExists(string email);
        Task<AuthenticationResponse> RegisterUser(RegisterUserRequest request);
        Task<AuthenticationResponse> LoginUser(LoginUserCommandRequest request);
        Task<string> GetUserId();
        Task<List<IdentityRole>> GetUserRoles(string id);
        Task<string> AddRoleToUser(string userId, string roleName);
        //Task<bool> UpdateUser(UpdateUserViewModel model);
    }
}
