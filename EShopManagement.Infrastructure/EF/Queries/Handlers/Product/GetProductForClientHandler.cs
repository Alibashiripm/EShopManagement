using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Product
{
    internal sealed class GetProductForClientHandler : IQueryHandler<GetProductForClient, ClientProductDto>
    {
        private readonly DbSet<Domain.Entities.Product.Product> _products;


        public GetProductForClientHandler(ReadDbContext context)
        {
            _products = context.Products;

        }
        public async Task<ClientProductDto> HandleAsync(GetProductForClient query)
        {
            var product = await _products
               .Include(p => p.ProductCategory)
               .ThenInclude(p=>p.ProductCategories)
               .Include(p=>p.ProductComments)
               .AsNoTracking()
               .SingleOrDefaultAsync(p => p._title.Value == query.Title);
            return product.AsClientProductDto();
        }
    }
}
