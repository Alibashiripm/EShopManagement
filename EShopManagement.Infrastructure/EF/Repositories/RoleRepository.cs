using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Repositories
{
    internal sealed class RoleRepository : IGenericRepository<Role, int>
    {
        private readonly DbSet<Role> _role;
        private readonly WriteDbContext _writeDbContext;

        public RoleRepository(WriteDbContext writeDbContext)
        {
            _role = writeDbContext.Roles;
            _writeDbContext = writeDbContext;
        }
 
        public async Task CreateAsync(Role entity)
        {
            await _role.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var role = await _role.SingleOrDefaultAsync(p => p.Id == Id);
            role.SoftDelete();
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Role>> GetAllAsync()
        => await _role.ToListAsync();


        public async Task<Role> GetByIdAsync(int Id)
       => await _role.SingleOrDefaultAsync(p => p.Id == Id);

        public async Task UpdateAsync(Role entity)
        {
             _role.Update(entity);
             await _writeDbContext.SaveChangesAsync();
        }
    } 
}
