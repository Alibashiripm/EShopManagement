using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Product
{
    internal sealed class GetAllProductsForClientHandler : IQueryHandler<GetAllProductsForClient, List<ClientProductsListDto>>
    {
        private readonly DbSet<Domain.Entities.Product.Product> _products;


        public GetAllProductsForClientHandler(ReadDbContext context)
        {
            _products = context.Products;

        }
        public async Task<List<ClientProductsListDto>> HandleAsync(GetAllProductsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;

             var filteredProducts = _products
                .Where(b =>
                    !b.IsDeleted &&
                    query.CategoryIds.Contains(b.CategoryId))
                .AsQueryable();

             var result =   filteredProducts
                .AsEnumerable()  
                .Where(b => b._title.Value.Contains(query.SearchPhrase) ||
                            b.Tags.Contains(query.SearchPhrase))
                .OrderBy(o => o._createDate.Value)
                .Skip(skip)
                .Take(query.TakeNumber)
                .Select(s => s.AsClientProductsListDto())
                .ToList();

            return result;
        }

    }
}
