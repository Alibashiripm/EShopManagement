using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Factories.Order;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class BlogService : IBlogService
    {

        private readonly DbSet<Blog > _blogs;
        private readonly DbSet<BlogComment> _blogComments;
        private readonly WriteDbContext writeDbContext;

        public BlogService(ReadDbContext readDbContext, WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext;
            _blogs = readDbContext.Blogs;
            _blogComments = writeDbContext.BlogComments;
        }
        public async Task ConfrimBlogCommentAsync(int CommentId)
        {
            var comment = await _blogComments.SingleOrDefaultAsync(c => c.Id == CommentId);
            comment.Confrim();
            await writeDbContext.SaveChangesAsync();

        }

        public async Task<bool> IsBlogExistWithIdAsync(int BlogId)
        {

            return await _blogs.AnyAsync(b => b.Id == BlogId);
        }

        public async Task<bool> IsBlogExistWithTitleAsync(string BlogTitle)
        {
            return await _blogs.AnyAsync(b => b._title.Value == BlogTitle);
        }
    }
}
