using EShopManagement.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Repositories
{
    public interface IGenericRepository<T,TKey> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(TKey Id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TKey Id);
 
       
    }
}
