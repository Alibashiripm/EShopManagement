using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class ProductCommentRepository : IGenericRepository<ProductComment, int>
    {
        private readonly DbSet<ProductComment> _productComments;
        private readonly WriteDbContext _writeDbContext;

        public ProductCommentRepository(WriteDbContext writeDbContext)
        {
            _productComments = writeDbContext.ProductComments ;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(ProductComment entity)
        {
            await _productComments.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var productComments = await _productComments.SingleOrDefaultAsync(p => p.Id == Id);
            productComments.RemoveConfirmation();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ProductComment>> GetAllAsync()
        => await _productComments.Include(p => p.Product).ToListAsync();


        public async Task<ProductComment> GetByIdAsync(int Id)
       => await _productComments.Include(p => p.Product).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(ProductComment entity)
        {
            _productComments.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    }
}
