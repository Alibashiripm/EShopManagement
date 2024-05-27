using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Product.Admin
{
    public class AdminProductCategoryDto
    {
        public int CategoryId { get;   set; }
        public string Title { get; set; }
        public bool IsDelete { get; set; }
        public int? ParentId { get; set; }
 
    }
}
