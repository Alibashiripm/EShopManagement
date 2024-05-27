using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.OrderDetail
{
    public class GetAllOrderDetails : IQuery<List<OrderDetailDto>>
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }  
}
