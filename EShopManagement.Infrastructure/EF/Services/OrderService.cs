using EShopManagement.Application.Commands.Order;
using EShopManagement.Application.Commands.OrderDetail;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Consts;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Domain.ValueObjects.User;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZarinpalSandbox;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class OrderService : IOrderService
    {

        private readonly WriteDbContext writeDbContext;
        private readonly ReadDbContext readDbContext;
        private readonly IServiceProvider _serviceProvider;
        public OrderService(ReadDbContext readDbContext, WriteDbContext writeDbContext, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.writeDbContext = writeDbContext;
            this.readDbContext = readDbContext;
        }

        public async Task AddProductToUserPurchasesAsync(int productId, int userId)
        {
            var user = await writeDbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var product = await writeDbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
            user.Products.Add(product);
            writeDbContext.Update(user);
            await writeDbContext.SaveChangesAsync();
        }

        public async Task<bool> DiscountCodeValidatorAsync(string code)
        {
            return await readDbContext.Discounts.AnyAsync(d => d._discountCode.Value == code);
        }

        public async Task FinalizeOrderAsync(int orderId, int userId)
        {

            var order = await writeDbContext.Orders.SingleOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);
            List<int?> productIds = order?.OrderDetails?.Select(o => o.ProductId)?.ToList();
            if (productIds != null)
            {
                var tasks = new List<Task>();

                foreach (var productId in productIds)
                {
                    tasks.Add(AddProductToUserPurchasesAsync(productId.Value, userId));
                }

                await Task.WhenAll(tasks);
            }

            order.Finalize();

            writeDbContext.Update(order);
            await writeDbContext.SaveChangesAsync();

        }

        public async Task<bool> HasUserBoughtTheProductAsync(int productId, int userId)
        {
            var user = await readDbContext.Users.Include(u => u.Products).SingleOrDefaultAsync(u => u.Id == userId);
            return user.Products.Any(p => p.Id == productId);
        }

        public async Task<bool> IsOrderExistWithIdAsync(int orderId)
        {
            return await readDbContext.Orders.AnyAsync(o => o.Id == orderId);
        }

        public async Task<string> HandleZarinpalPaymentAsync(string Email, decimal Amount, string Description, string CallBackUrl, int OrderId)
        {

            //var payment = new Zarinpal.Payment(".", 21000);
            var payment = new Payment((int)Amount);

            var res = payment.PaymentRequest(Description, $"{CallBackUrl}?orderId=" + OrderId, Email);

            if (res.Result.Status == 100)
            {
                return $"https://sandbox.zarinpal.com/pg/StartPay/{res.Result.Authority}";
            }

            return null;
        }

        public Task<Order> UpdateOrderSumAsync(int orderId)
        {
            throw new NotImplementedException();
        }
        public async Task<string> InvoicePaymentAsync(string email, string description, string callBackUrl, int orderId)
        {
            var order = await readDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            var result = await HandleZarinpalPaymentAsync(email, order.OrderSum, description, callBackUrl, orderId);
            if (result is not null)
            {
                return result;
            }
            return "0";
        }

        public async Task<bool> InvoicePaymentResultAsync(int orderId, int userId, IQueryCollection reuestQueries)
        {
            var order = await readDbContext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(f => f.Id == orderId);
            var UserService = _serviceProvider.GetRequiredService<UserManager<User>>();
            if (reuestQueries["Status"] != "" &&
                    reuestQueries["Status"].ToString().ToLower() == "ok"
                    && reuestQueries["Authority"] != "")
            {
                string authority = reuestQueries["Authority"];
                var user = await UserService.FindByIdAsync(userId.ToString());
                //var payment = new Zarinpal.Payment(".", 30000);
                var payment = new Payment(30000);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.Finalize();
                    foreach (var detail in order.OrderDetails)
                    {
                        await AddProductToUserPurchasesAsync(detail.ProductId.Value, userId);
                    }
                    writeDbContext.SaveChanges();
                    return true;
                }
            }
            return false;//Fail
        }


        public async Task<DiscountResponseType> ApplyDiscount(int orderId, string code)
        {

            var discount = readDbContext.Discounts.SingleOrDefault(d => d._discountCode.Value == code);
            var order = readDbContext.Orders.SingleOrDefault(d => d.Id == orderId);

            if (discount == null)
                return DiscountResponseType.NotFound;

            if (discount._dateRange.StartDate != null && discount._dateRange.StartDate > DateTime.Now)
                return DiscountResponseType.ExpierDate;

            if (discount._dateRange.EndDate != null && discount._dateRange.EndDate <= DateTime.Now)
                return DiscountResponseType.ExpierDate;


            if (discount.UsableCount != null && discount.UsableCount < 1)
                return DiscountResponseType.Finished;

            bool isUserUsed = readDbContext.UserDiscountCodes.Any(d => d.UserId == order.UserId && d.Id == discount.Id);
            if (isUserUsed)
                return DiscountResponseType.UserUsed;

            decimal percent = (order.OrderSum * discount._discountPercent.Value) / 100;
            order.ApplyDiscounts(percent);
            writeDbContext.Update(order);
            if (discount.UsableCount != null)
            {
                discount.ReduceCount();
            }
            writeDbContext.Discounts.Update(discount);
            await writeDbContext.UserDiscountCodes.AddAsync(new UserDiscountCode()
            {
                UserId = order.UserId,
                Id = discount.Id
            });
            await writeDbContext.SaveChangesAsync();
            return DiscountResponseType.Success;
        }
    }
}
