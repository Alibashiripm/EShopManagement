using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.ValueObjects.Order.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Order
{
    public interface IDiscountFactory
    {
        Discount Create(DiscountCode discountCode, DiscountPercent discountPercent, DiscountDateRange dateRange, int usableCount, bool isDelete);
    }
}
