using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.Queries.OrderDetail;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.OrderDetail
{
    internal sealed class GetOrderDetailHandler : IQueryHandler<GetOrderDetail, OrderDetailDto>
    {
        private readonly DbSet<OrderDetailReadModel> _orderDetails;


        public GetOrderDetailHandler(ReadDbContext context)
        {
            _orderDetails = context.OrderDetails;

        }
        public async Task<OrderDetailDto> HandleAsync(GetOrderDetail query)
        {
            var orderDetail = await _orderDetails
                 .Include(o => o.Order)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(b => b.Order.UserId == query.UserId && b.OrderId == query.OrderId && b.Id == query.OrderDetailId);
             return orderDetail.AsOrderDetailDto();
        }
    }
}
