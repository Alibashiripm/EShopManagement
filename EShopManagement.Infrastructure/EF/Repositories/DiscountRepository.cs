using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class DiscountRepository : IGenericRepository<Discount, int>
    {
        private readonly DbSet<Discount> _discount;
        private readonly WriteDbContext _writeDbContext;

        public DiscountRepository(WriteDbContext writeDbContext)
        {
            _discount = writeDbContext.Discounts;
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Discount entity)
        {
            await _discount.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var discount = await _discount.SingleOrDefaultAsync(p => p.Id == Id);
            discount.SoftRemove();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Discount>> GetAllAsync()
        => await _discount.ToListAsync();


        public async Task<Discount> GetByIdAsync(int Id)
       => await _discount.SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(Discount entity)
        {
            _discount.Update(entity);
            await _writeDbContext.SaveChangesAsync();
        }
    }

}
