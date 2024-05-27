using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }     
        public int UserId { get; set; }
        public decimal OrderSum { get; set; }
        public bool IsFinaly { get; set; }
        public DateTime CreateDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
