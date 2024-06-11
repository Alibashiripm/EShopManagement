using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.Queries.Order;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Order
{
    internal sealed class GetUserOrderHandler : IQueryHandler<GetUserOrder, OrderDto>
    {
        private readonly DbSet<Domain.Entities.Order.Order > _orders;


        public GetUserOrderHandler(ReadDbContext context)
        {
            _orders = context.Orders;

        }
        public async Task<OrderDto> HandleAsync(GetUserOrder query)
        {
            var order=  await _orders
                 .Include(o => o.OrderDetails)
               .AsNoTracking()
                .SingleOrDefaultAsync(b => b.UserId == query.UserId && b.Id == query.OrderId);
            return order.AsOrderDto();
        }
    }
}
