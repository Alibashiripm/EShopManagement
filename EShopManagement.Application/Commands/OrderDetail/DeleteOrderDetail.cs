using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.OrderDetail
{
    public record DeleteOrderDetail(int DetailId):ICommand;
}
