 
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Blog
{
    internal sealed class GetBlogForClientHandler : IQueryHandler<GetBlogForClient, ClientBlogDto>
    {
        private readonly DbSet<BlogReadModel> _blogs;

        public GetBlogForClientHandler(ReadDbContext context)
        {
            _blogs = context.Blogs;
         }
        public async Task<ClientBlogDto>HandleAsync(GetBlogForClient query)
        {
            var blog = await _blogs.SingleOrDefaultAsync(b => b.Title == query.BlogTitle);
            return blog.AsClientBlogDto();
        }
    }  
}
