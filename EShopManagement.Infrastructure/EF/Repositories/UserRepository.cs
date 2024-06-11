using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class UserRepository : IGenericRepository<User, int>
    {
        private readonly DbSet<User> _user;
        private readonly WriteDbContext _writeDbContext;

        public UserRepository(WriteDbContext writeDbContext)
        {
            _user = writeDbContext.Users;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(User entity)
        {
            await _user.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var product = await _user.SingleOrDefaultAsync(p => p.Id == Id);
            product.SoftDelete();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        => await _user.Include(p => p.Products) .ToListAsync();


        public async Task<User> GetByIdAsync(int Id)
       => await _user.Include(p => p.Products)  .SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(User entity)
        {
             _user.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    }  
}
