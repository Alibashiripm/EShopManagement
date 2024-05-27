using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class BlogCommentRepository : IGenericRepository<BlogComment, int>
    {
        private readonly DbSet<BlogComment> _blogComments;
        private readonly WriteDbContext _writeDbContext;

        public BlogCommentRepository(WriteDbContext writeDbContext)
        {
            _blogComments = writeDbContext.BlogComments;
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(BlogComment entity)
        {
            await _blogComments.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var blogComment = await _blogComments.SingleOrDefaultAsync(p => p.Id == Id);
            blogComment.RemoveConfirmation();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<BlogComment>> GetAllAsync()
        => await _blogComments.Include(p => p.Blog).ToListAsync();


        public async Task<BlogComment> GetByIdAsync(int Id)
       => await _blogComments.Include(p => p.Blog).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(BlogComment entity)
        {
            _blogComments.Update(entity);
            await _writeDbContext.SaveChangesAsync();
        }
    } 

}
