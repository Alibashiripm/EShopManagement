using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Product
{
    public class GetProductForAdmin : IQuery<AdminProductDto>
    {
        public int ProductId{ get; set; }
    } 
}
