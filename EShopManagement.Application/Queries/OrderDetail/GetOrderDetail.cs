using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.OrderDetail
{
    public class GetOrderDetail : IQuery<OrderDetailDto>
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
    }
}
