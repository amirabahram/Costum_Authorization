using Microsoft.AspNetCore.Identity;
using RBAC.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Domain.Entities.Products
{
    public class ProductRole : BaseEntity
    {
        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
