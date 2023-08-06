using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Presistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RbacContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(UserManager<IdentityUser> userManager, RbacContext db,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            _db = db;
            _roleManager = roleManager;
        }


        public async Task<List<IdentityUser>> GetAllUsers()
        {
              return  await _userManager.Users.ToListAsync();
             
            
        }
        public async Task<List<IdentityRole>> GetAllRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
