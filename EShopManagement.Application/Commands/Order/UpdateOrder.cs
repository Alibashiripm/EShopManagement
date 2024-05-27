using EShopManagement.Application.DTOs.Order;
using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Order
{
    public record UpdateOrder(OrderDto Order):ICommand;
}
