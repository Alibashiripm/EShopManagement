using EShopManagement.Shared.Abstractions.Commands;


namespace EShopManagement.Application.Commands.ProductCategory
{
    public record DeleteProductCategory(int CategoryId):ICommand;
}
