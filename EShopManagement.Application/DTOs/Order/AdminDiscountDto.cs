using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Order
{
    public class AdminDiscountDto
    {
        public int Id { get; set; }
        public string Code { get; set;}
        public int Percent { get; set; }
        public int UsableCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
