using RBAC.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Domain.IRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<string> GetUserIdByProductId(int productId);
    }
}
