using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Domain.IRepositories
{
    public interface IUserRepository 
    {
        Task<List<IdentityUser>> GetAllUsers();
        
    }
}
