using AutoMapper;
using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Application.Queries.BlogComment;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.BlogComment
{
    internal sealed class GetAllBlogCommentsForAdminHandler : IQueryHandler<GetAllBlogCommentsForAdmin, List<AdminBlogCommentDto>>
    {
        private readonly DbSet<Domain.Entities.Blog.BlogComment> _blogComments;


        public GetAllBlogCommentsForAdminHandler(ReadDbContext context)
        {
            _blogComments = context.BlogComments;

        }
        public async Task<List<AdminBlogCommentDto>> HandleAsync(GetAllBlogCommentsForAdmin query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _blogComments
                 .Where(b => query.BlogIds.Contains(b.BlogId)
                 &&b.IsConfirmed == query.IsConfirmed
                 &&b._createDate.Value > query.StartDate
                 &&b._createDate.Value < query.EndDate)
                 .OrderBy(o => o._createDate.Value)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsAdminBlogCommentDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }   
}
