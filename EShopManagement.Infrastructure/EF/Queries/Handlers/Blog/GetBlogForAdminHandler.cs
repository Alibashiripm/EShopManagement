using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Blog
{
    internal sealed class GetBlogForAdminHandler : IQueryHandler<GetBlogForAdmin, AdminBlogDto>
    {
        private readonly DbSet<Domain.Entities.Blog.Blog> _blogs;

        public GetBlogForAdminHandler(ReadDbContext context)
        {
            _blogs = context.Blogs;
         }
        public async Task<AdminBlogDto> HandleAsync(GetBlogForAdmin query)
        {
            var blog = await _blogs.SingleOrDefaultAsync(b => b.Id == query.BlogId);
            return blog.AsAdminBlogDto();
        }
    }
}
