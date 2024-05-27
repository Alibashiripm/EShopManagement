using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.Order
{
    public class GetUserAllOrders : IQuery<List<OrderDto>>
    {
        public int UserId { get; set; }
    } 

}
