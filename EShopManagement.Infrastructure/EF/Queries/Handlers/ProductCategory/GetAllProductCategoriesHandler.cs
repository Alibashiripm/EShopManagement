using EShopManagement.Application.DTOs.Product;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Application.Queries.ProductCategory;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.ProductCategory
{

    internal sealed class GetAllProductCategoriesHandler : IQueryHandler<GetAllProductCategories, List<ProductCategoriesListDto>>
    {
        private readonly DbSet<ProductCategoryReadModel> _productCategories;


        public GetAllProductCategoriesHandler(ReadDbContext context)
        {
            _productCategories = context.ProductCategories;
        }
        public async Task<List<ProductCategoriesListDto>> HandleAsync(GetAllProductCategories query)
        {
            return await _productCategories           
                 .Select(s => s.AsProductCategoriesListDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }  
}
