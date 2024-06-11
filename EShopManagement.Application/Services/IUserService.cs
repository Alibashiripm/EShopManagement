using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Application.Queries.User;
using EShopManagement.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        Task<bool> ConfrimEmailAsync(string userName, string activeCode);
        Task<SignInResult> LoginAsync(LoginUser query);
        Task<bool> PremiumSubscriptionAsync(int orderId, int userId, IQueryCollection reuestQueries);
        Task<string> PremiumSubscriptionPaymentAsync(string email, int amount, string description, string callBackUrl, int orderId);
        Task<IdentityResult> RegisterUserAsync(User user,string password);
        Task UpdatePasswordAsync(User user, string oldPassword, string newPassword);
    }
}
