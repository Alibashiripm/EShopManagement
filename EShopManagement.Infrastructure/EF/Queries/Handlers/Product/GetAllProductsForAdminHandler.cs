using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.Queries.Order;
using EShopManagement.Application.Queries.Product;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Product
{

    internal sealed class GetAllProductsForAdminHandler : IQueryHandler<GetAllProductsForAdmin, List<AdminPtoductsListDto>>
    {
        private readonly DbSet<Domain.Entities.Product.Product> _products;


        public GetAllProductsForAdminHandler(ReadDbContext context)
        {
            _products = context.Products;

        }
        public async Task<List<AdminPtoductsListDto>> HandleAsync(GetAllProductsForAdmin query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _products
                 .Where(b =>
                 b._title.Value.Contains(query.SearchPhrase) ||
                 b.Tags.Contains(query.SearchPhrase) &&
                 query.CategoryIds.Contains(b.CategoryId))
                 .OrderBy(o => o._createDate.Value)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsAdminPtoductsListDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
