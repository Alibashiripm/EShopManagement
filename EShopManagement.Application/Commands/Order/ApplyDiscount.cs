using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Order
{
    public record ApplyDiscount(int OrderId,string Code):ICommand;


}
