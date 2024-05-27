using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.Queries.ProductCategory;
using EShopManagement.Application.Queries.ProductComment;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.ProductComments
{

    internal sealed class GetAllProductCommentsForAdminHandler : IQueryHandler<GetAllProductCommentsForAdmin, List<AdminProductCommentDto>>
    {
        private readonly DbSet<ProductCommentReadModel> _productComments;


        public GetAllProductCommentsForAdminHandler(ReadDbContext context)
        {
            _productComments = context.ProductComments;
        }
        public async Task<List<AdminProductCommentDto>> HandleAsync(GetAllProductCommentsForAdmin query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _productComments
                 .Where(b => query.ProductIds.Contains(b.ProductId)
                 && b.IsConfirmed == query.IsConfirmed
                 && b.CreateDate > query.StartDate
                 && b.CreateDate < query.EndDate)
                 .OrderBy(o => o.CreateDate)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsAdminProductCommentDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
