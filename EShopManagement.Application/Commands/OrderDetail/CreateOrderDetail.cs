

using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.OrderDetail
{
    public record CreateOrderDetail(OrderDetailDto DetailDto):ICommand;
}
