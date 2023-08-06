using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBAC.Domain.Entities.Products;
using RBAC.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Presistence.Repositories
{
    public class ProductRepository : BaseRepository<RbacContext, Product>, IProductRepository
    {
        private readonly RbacContext _db;
        public ProductRepository(RbacContext context) => _db = context ;

        public async Task<string> GetUserIdByProductId(int productId)
        {
            var product = _db.Products.Where(i=>i.Id == productId).FirstOrDefault();
            return  product.UserId;
        }
    }
}
