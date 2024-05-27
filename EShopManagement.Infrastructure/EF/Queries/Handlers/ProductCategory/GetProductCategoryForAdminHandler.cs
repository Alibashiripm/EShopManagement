using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.Queries.ProductCategory;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.ProductCategory
{
    internal sealed class GetProductCategoryForAdminHandler : IQueryHandler<GetProductCategoryForAdmin, AdminProductCategoryDto>
    {
        private readonly DbSet<ProductCategoryReadModel> _productCategories;


        public GetProductCategoryForAdminHandler(ReadDbContext context)
        {
            _productCategories = context.ProductCategories;
        }
        public async Task<AdminProductCategoryDto> HandleAsync(GetProductCategoryForAdmin query)
        {
            var category = await _productCategories.Include(c=>c.ProductCategories)
            .AsNoTracking().SingleOrDefaultAsync(c => c.Id == query.CategoryId);
               return   category.AsAdminProductCategoryDto();
                 
             
        }
    }
}
