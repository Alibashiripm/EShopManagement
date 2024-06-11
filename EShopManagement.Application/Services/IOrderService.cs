using EShopManagement.Domain.Consts;
using EShopManagement.Domain.Entities.Order;
using Microsoft.AspNetCore.Http;


namespace EShopManagement.Application.Services
{
    public interface IOrderService
    {
        Task<Order> UpdateOrderSumAsync(int orderId);
        Task FinalizeOrderAsync(int orderId,int userId);
        Task<bool> IsOrderExistWithIdAsync(int orderId);
        Task<bool> HasUserBoughtTheProductAsync(int productId,int userId);
        Task AddProductToUserPurchasesAsync(int productId,int userId);
        Task<string> HandleZarinpalPaymentAsync(string Email, decimal Amount, string Description, string CallBackUrl, int OrderId);
        Task<string> InvoicePaymentAsync(string email, string description, string callBackUrl, int orderId);

        #region Discount
         Task<bool> DiscountCodeValidatorAsync(string code);
        Task<DiscountResponseType> ApplyDiscount(int orderId, string code);
        Task<bool> InvoicePaymentResultAsync(int orderId, int userId, IQueryCollection reuestQueries);
        #endregion
    }
}
