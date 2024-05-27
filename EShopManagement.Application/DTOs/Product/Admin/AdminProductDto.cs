using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Product.Admin
{
    public class AdminProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; } 
        public string ShortDescription { get; set; }
        public string FileName { get; set; }
        public decimal Price{ get; set; }
        public string Tags { get; set; }
        public int? SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public long CellerId { get; set; }
        public string ImageName { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsPremium { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
