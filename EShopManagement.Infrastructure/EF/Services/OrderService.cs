using EShopManagement.Application.Services;
using EShopManagement.Domain.Consts;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class OrderService : IOrderService
    {


        private readonly WriteDbContext writeDbContext;
        private readonly ReadDbContext readDbContext;

        public OrderService(ReadDbContext readDbContext, WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext;
            this.readDbContext = readDbContext;
        }

        public async Task AddProductToUserPurchasesAsync(int productId, int userId)
        {
            var user = await writeDbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var product = await writeDbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
            user.Products.Add(product);
            await writeDbContext.SaveChangesAsync();
        }

        public async Task<bool> DiscountCodeValidatorAsync(string code)
        {
            return await readDbContext.Discounts.AnyAsync(d => d.DiscountCode == code);
        }

        public async Task FinalizeOrderAsync(int orderId, int userId)
        {

            var order = await writeDbContext.Orders.SingleOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);
            List<int> productIds = order.OrderDetails.Select(o => o.ProductId).ToList();
            var tasks = new List<Task>();

            foreach (var productId in productIds)
            {
                tasks.Add(AddProductToUserPurchasesAsync(productId, userId));
            }

            await Task.WhenAll(tasks);
            order.Finalize();
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

        public Task<Order> UpdateOrderSumAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<DiscountResponseType> UseDiscountAsync(int OrderId, string code)
        {
            var discount = await writeDbContext.Discounts.SingleOrDefaultAsync(d => d._discountCode.Value == code);

            if (discount == null)
                return DiscountResponseType.NotFound;

            if (discount._dateRange.StartDate != null && discount._dateRange.StartDate > DateTime.Now)
                return DiscountResponseType.ExpierDate;

            if (discount._dateRange.EndDate != null && discount._dateRange.EndDate <= DateTime.Now)
                return DiscountResponseType.ExpierDate;


            if (discount.UsableCount != null && discount.UsableCount < 1)
                return DiscountResponseType.Finished;

            var order = await writeDbContext.Orders.SingleOrDefaultAsync(o => o.Id == OrderId);

            if (readDbContext.UserDiscountCodes.Any(d => d.UserId == order.UserId && d.DiscountCode == discount._discountCode.Value))
                return DiscountResponseType.UserUsed;

            var percent = (order.OrderSum * discount._discountPercent.Value) / 100;
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
