using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Domain.Entities.Common
{
    public static class ResultMessages
    {
        public const string CREATED_PRODUCT_SUCCESSFULLY = "Product has been added!";
        public const string DELETED_PRODUCT_PERMANENTLY = "Product has been deleted permanently!";

        public const string CREATED_USER_SUCCESSFULLY = "User has been added!";
        public const string DELETED_USER_PERMANENTLY = "User has been deleted permanently!";

        public const string UPDATED_USER_SUCCESSFULLY = "User has been updated!";
        public const string UPDATED_PRODUCT_SUCCESSFULLY = "Product has been updated!";
    }
}
