using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Commands;


namespace EShopManagement.Application.Commands.ProductCategory
{
    public record UpdateProductCategory(AdminProductCategoryDto CategoryDto):ICommand;
}
