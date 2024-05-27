using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Product.Client
{
    public class ClientProductsListDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
    }  
}
