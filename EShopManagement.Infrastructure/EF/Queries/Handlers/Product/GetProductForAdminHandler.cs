using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Product
{
    internal sealed class GetProductForAdminHandler : IQueryHandler<GetProductForAdmin, AdminProductDto>
    {
        private readonly DbSet<ProductReadModel> _products;


        public GetProductForAdminHandler(ReadDbContext context)
        {
            _products = context.Products;

        }
        public async Task<AdminProductDto> HandleAsync(GetProductForAdmin query)
        {
            var product = await _products
               .Include(p => p.ProductCategory)
               .AsNoTracking()
               .SingleOrDefaultAsync(p => p.Id == query.ProductId);
        return product.AsAdminProductDto();
        }
    }
}
