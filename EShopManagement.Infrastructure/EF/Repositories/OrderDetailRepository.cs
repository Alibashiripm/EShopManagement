using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class OrderDetailRepository : IGenericRepository<OrderDetail, int>
    {
        private readonly DbSet<OrderDetail> _orderDetail;
        private readonly WriteDbContext _writeDbContext;

        public OrderDetailRepository(WriteDbContext writeDbContext)
        {
            _orderDetail = writeDbContext.OrderDetails;
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(OrderDetail entity)
        {
            await _orderDetail.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var orderDetail = await _orderDetail.SingleOrDefaultAsync(p => p.Id == Id);
            orderDetail.SoftRemove();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<OrderDetail>> GetAllAsync()
        => await _orderDetail.Include(p => p.Order).ToListAsync();


        public async Task<OrderDetail> GetByIdAsync(int Id)
       => await _orderDetail.Include(p => p.Order).SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(OrderDetail entity)
        {
            _orderDetail.Update(entity);
            await _writeDbContext.SaveChangesAsync();
        }
    } 

}
