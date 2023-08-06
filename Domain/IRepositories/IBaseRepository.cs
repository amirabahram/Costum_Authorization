using RBAC.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RBAC.Domain.Entities;

namespace RBAC.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
