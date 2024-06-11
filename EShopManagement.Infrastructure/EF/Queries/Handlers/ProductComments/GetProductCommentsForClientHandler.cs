using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Application.Queries.ProductComment;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.ProductComments
{
    internal sealed class GetProductCommentsForClientHandler : IQueryHandler<GetProductCommentsForClient, List<ClientProductCommentDto>>
    {
        private readonly DbSet<Domain.Entities.Product.ProductComment> _productComments;


        public GetProductCommentsForClientHandler(ReadDbContext context)
        {
            _productComments = context.ProductComments;
        }
        public async Task<List<ClientProductCommentDto>> HandleAsync(GetProductCommentsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _productComments
                 .Where(b => b.ProductId == query.ProductId)
                 .OrderBy(o => o._createDate.Value)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsClientProductCommentDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
