using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class ProductRepository : IGenericRepository<Product, int>
    {
        private readonly DbSet<Product> _products;
        private readonly WriteDbContext _writeDbContext;

        public ProductRepository(WriteDbContext writeDbContext)
        {
            _products = writeDbContext.Products;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(Product entity)
        {
            await _products.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var product = await _products.SingleOrDefaultAsync(p => p.Id == Id);
            product.SoftDelete();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        => await _products.Include(p => p.ProductComments).Include(p => p.ProductCategory).ToListAsync();


        public async Task<Product> GetByIdAsync(int Id)
       => await _products.Include(p => p.ProductComments).Include(p => p.ProductCategory).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(Product entity)
        {
            _products.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    }
}
