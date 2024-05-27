using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.ProductCategory
{
    public class GetProductCategoryForAdmin :IQuery<AdminProductCategoryDto>
    {
        public int CategoryId { get; set; }
    }
}
