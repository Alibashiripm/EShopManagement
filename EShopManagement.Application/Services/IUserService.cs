using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Services
{
    public interface IUserService
    {
 
        Task<bool> CheckingCorrectnessOfOldPasswordAsync(Domain.Entities.User.User user,string oldPassword );
        Task LoginAsync(string info, bool isPersistent, string password);
        Task RegisterUserAsync(User user,string password);
        Task UpdatePasswordAsync(User user, string oldPassword, string newPassword);
    }
}
