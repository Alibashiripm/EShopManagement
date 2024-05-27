using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Product
{
    public record DeleteProduct(int ProductId) :ICommand;
    
}
