using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Product
{
    public record UpdateProduct(AdminProductDto PtoductDto) :ICommand;
    
}
