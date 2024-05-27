using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class ProductCategoryRepository : IGenericRepository<ProductCategory, int>
    {
        private readonly DbSet<ProductCategory> _productCategorys;
        private readonly WriteDbContext _writeDbContext;

        public ProductCategoryRepository(WriteDbContext writeDbContext)
        {
            _productCategorys = writeDbContext.ProductCategories;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(ProductCategory entity)
        {
            await _productCategorys.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var productCategory = await _productCategorys.SingleOrDefaultAsync(p => p.Id == Id);
            productCategory.SoftDelete();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ProductCategory>> GetAllAsync()
        => await _productCategorys.Include(p => p.ProductCategories).ToListAsync();


        public async Task<ProductCategory> GetByIdAsync(int Id)
       => await _productCategorys.Include(p => p.ProductCategories).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(ProductCategory entity)
        {
            _productCategorys.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    }
}
