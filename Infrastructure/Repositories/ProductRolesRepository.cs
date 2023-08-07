using Microsoft.EntityFrameworkCore;
using RBAC.Domain.Entities.Products;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Presistence.Repositories
{
    public class ProductRolesRepository : BaseRepository<RbacContext, ProductRole>, IProductRolesRepository
    {
        private readonly RbacContext _rbacContext;
        
        public ProductRolesRepository(RbacContext rbacContext)
        {
            this._rbacContext = rbacContext;
        }

        public Task DeleteRolesByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductRole>> GetRolesByProductId(int id)
        {
            return await _rbacContext.ProductRoles.Where(o=>o.ProductId == id).ToListAsync();
        }
    }
}
