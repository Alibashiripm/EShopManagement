using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.Queries.Order;
using EShopManagement.Application.Queries.OrderDetail;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.OrderDetail
{

    internal sealed class GetAllOrderDetailsHandler : IQueryHandler<GetAllOrderDetails, List<OrderDetailDto>>
    {
        private readonly DbSet<OrderDetailReadModel> _orderDetails;


        public GetAllOrderDetailsHandler(ReadDbContext context)
        {
            _orderDetails = context.OrderDetails;

        }
        public async Task<List<OrderDetailDto>> HandleAsync(GetAllOrderDetails query)
        {
            return await _orderDetails
                .Where(b => b.Order.UserId == query.UserId&&b.OrderId == query.OrderId)
                .Include(o => o.Order)
                .Select(s => s.AsOrderDetailDto())
                .AsNoTracking()
                .ToListAsync();
        }
    } 
}
