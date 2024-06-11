using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.Queries.BlogComment;
using EShopManagement.Application.Queries.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Infrastructure.EF.Contexts;

using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Order
{

    internal sealed class GetUserAllOrdersHandler : IQueryHandler<GetUserAllOrders, List<OrderDto>>
    {
        private readonly DbSet<Domain.Entities.Order.Order> _orders;


        public GetUserAllOrdersHandler(ReadDbContext context)
        {
            _orders = context.Orders;

        }
        public async Task<List<OrderDto>> HandleAsync(GetUserAllOrders query)
        {
            var filteredOrders = _orders
           .Where(b =>
 
               b.UserId == query.UserId)
           .AsQueryable();
            var result = filteredOrders
               .AsEnumerable()
               .OrderBy(o => o._createDate.Value)
               .Select(s => s.AsOrderDto())
               .ToList();
            return result;
        }
    }
}
