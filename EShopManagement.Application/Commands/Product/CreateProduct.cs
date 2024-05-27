using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Product
{
    public record CreateProduct(AdminProductDto PtoductDto) :ICommand;
    
}
