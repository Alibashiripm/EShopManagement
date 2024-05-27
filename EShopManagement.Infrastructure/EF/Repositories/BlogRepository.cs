using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class BlogRepository : IGenericRepository<Blog, int>
    {
        private readonly DbSet<Blog> _blogs;
        private readonly WriteDbContext _writeDbContext;

        public BlogRepository(WriteDbContext writeDbContext)
        {
            _blogs = writeDbContext.Blogs;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(Blog entity)
        {
            await _blogs.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var product = await _blogs.SingleOrDefaultAsync(p => p.Id == Id);
            product.SoftDelete();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Blog>> GetAllAsync()
        => await _blogs.Include(p => p.BlogComments).ToListAsync();


        public async Task<Blog> GetByIdAsync(int Id)
       => await _blogs.Include(p => p.BlogComments).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(Blog entity)
        {
            _blogs.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    }

}
