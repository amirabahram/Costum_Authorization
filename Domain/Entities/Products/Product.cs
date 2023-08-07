using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RBAC.Domain.Entities.Common;

namespace RBAC.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Title { get; set; }
        public List<ProductRole> PermittedRoles { get; set; }
    }
}
