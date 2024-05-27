using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.Queries.BlogComment;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.BlogComment
{
    internal sealed class GetBlogCommentForAdminHandler : IQueryHandler<GetBlogCommentForAdmin, AdminBlogCommentDto>
    {
        private readonly DbSet<BlogCommentReadModel> _blogComments;


        public GetBlogCommentForAdminHandler(ReadDbContext context)
        {
            _blogComments = context.BlogComments;

        }
        public async Task<AdminBlogCommentDto> HandleAsync(GetBlogCommentForAdmin query)
        {     
            var blogComment = await _blogComments.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == query.CommentId);
            return blogComment.AsAdminBlogCommentDto();
       }
    }
}
