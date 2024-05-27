using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Order
{
    public record DeleteOrder(int OrderId):ICommand;
}
