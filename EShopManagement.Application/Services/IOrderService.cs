using EShopManagement.Domain.Consts;
using EShopManagement.Domain.Entities.Order;
 

namespace EShopManagement.Application.Services
{
    public interface IOrderService
    {
        Task<Order> UpdateOrderSumAsync(int orderId);
        Task FinalizeOrderAsync(int orderId,int userId);
        Task<bool> IsOrderExistWithIdAsync(int orderId);
        Task<bool> HasUserBoughtTheProductAsync(int productId,int userId);
        Task AddProductToUserPurchasesAsync(int productId,int userId);
 
        #region DisCount
        Task<DiscountResponseType> UseDiscountAsync(int OrderId, string code);
        Task<bool> DiscountCodeValidatorAsync(string code);
        #endregion
    }
}
