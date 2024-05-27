using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Product
{
    internal sealed class GetAllProductsForClientHandler : IQueryHandler<GetAllProductsForClient, List<ClientProductsListDto>>
    {
        private readonly DbSet<ProductReadModel> _products;


        public GetAllProductsForClientHandler(ReadDbContext context)
        {
            _products = context.Products;

        }
        public async Task<List<ClientProductsListDto>> HandleAsync(GetAllProductsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _products
                 .Where(b =>
                 b.Title.Contains(query.SearchPhrase) ||
                 b.Tags.Tags.Contains(query.SearchPhrase) &&
                 query.CategoryIds.Contains(b.CategoryId))
                 .OrderBy(o => o.CreateDate)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsClientProductsListDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
