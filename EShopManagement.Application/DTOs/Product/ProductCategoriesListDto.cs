using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Product
{
    public class ProductCategoriesListDto
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int CategoryParentId { get; set; }
    }
}
