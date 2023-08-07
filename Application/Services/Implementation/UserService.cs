using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RBAC.Application.Features.Commands.CreateEvent;
using RBAC.Application.Services.Interfaces;
using RBAC.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public UserService(IMapper mapper,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            RoleManager<IdentityRole> roleManager)
        {
            this._mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _httpContext = httpContextAccessor;
            _roleManager = roleManager;

        }
        public async Task<bool> EmailExists(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result == null) { return false; }
            return true;
            
        }

        public async Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),


            }
                .Union(userClaims)
                .Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JWT:Duration"])),
                signingCredentials: credentials
                );
            return  new AuthenticationResponse()
            {
                IsSuccess = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<AuthenticationResponse> LoginUser(LoginUserCommandRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthenticationResponse()
                {
                    Errors = new[] { "UserName or Password is incorrect!" }
                };
            }
            var result = await _userManager.CheckPasswordAsync(user,request.Password);
            if (result == false)
            {
                return new AuthenticationResponse()
                {
                    Errors = new[] { "UserName or Password is incorrect!" }
                };
            }
            return await GenerateAuthenticationResponseForUserAsync(user);
        }

        public async Task<AuthenticationResponse> RegisterUser(RegisterUserRequest model)
        {
            var emailCheck = await EmailExists(model.Email);
            if (emailCheck == true)
            {
                return new AuthenticationResponse()
                {
                    Errors = new[] { "User Already Exists!" }
                };
            }

            var user = _mapper.Map<IdentityUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                var output = await GenerateAuthenticationResponseForUserAsync(user);
                return output;
            }
            else
            {
                
                return new AuthenticationResponse()
                {
                    Errors = new[] { "Unable To Create User!" }
                };
            }

           
            
        }
        public async Task<string> GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        }

        public async Task<string> AddRoleToUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;
            if (!await _roleManager.RoleExistsAsync(roleName)) return null;
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded) return $"Role {roleName} added to {user.UserName}";
            return "Something Wents Wrong!";
            
        }

        public async Task<List<IdentityRole>> GetUserRoles(string id)
        {
            
            var user = await _userManager.FindByIdAsync(id);
         
            var roles = await _userManager.GetRolesAsync(user);
            var identityRoles = new List<IdentityRole>();
            foreach (var role in roles)
            {
                var identityRole = await _roleManager.FindByNameAsync(role);
                identityRoles.Add(identityRole);
            }
            return identityRoles;
        }
    }
}
