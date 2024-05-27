using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.Queries.BlogComment;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.BlogComment
{
    internal sealed class GetBlogCommentsForClientHandler : IQueryHandler<GetBlogCommentsForClient, List<ClientBlogCommentDto>>
    {
        private readonly DbSet<BlogCommentReadModel> _blogComments;
        public GetBlogCommentsForClientHandler(ReadDbContext context)
        {
            _blogComments = context.BlogComments;
        }
        public async Task<List<ClientBlogCommentDto>> HandleAsync(GetBlogCommentsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _blogComments
                 .Where(b => b.BlogId == query.BlogId)
                 .OrderBy(o => o.CreateDate)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsClientBlogCommentDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
