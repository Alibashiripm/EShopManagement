using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Commands;


namespace EShopManagement.Application.Commands.ProductCategory
{
    public record CreateProductCategory(AdminProductCategoryDto CategoryDto):ICommand;
}
