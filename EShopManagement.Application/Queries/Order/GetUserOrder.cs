using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Order
{
    public class GetUserOrder : IQuery<OrderDto>
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    } 

}
