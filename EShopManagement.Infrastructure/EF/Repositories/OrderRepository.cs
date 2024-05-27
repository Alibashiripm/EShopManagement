using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class OrderRepository : IGenericRepository<Order, int>
    {
        private readonly DbSet<Order> _order;
        private readonly WriteDbContext _writeDbContext;

        public OrderRepository(WriteDbContext writeDbContext)
        {
            _order = writeDbContext.Orders;
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Order entity)
        {
            await _order.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var order = await _order.SingleOrDefaultAsync(p => p.Id == Id);
            order.SoftRemove();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAllAsync()
        => await _order.Include(p => p.OrderDetails).ToListAsync();


        public async Task<Order> GetByIdAsync(int Id)
       => await _order.Include(p => p.OrderDetails).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(Order entity)
        {
            _order.Update(entity);
            await _writeDbContext.SaveChangesAsync();
        }
    } 

}
