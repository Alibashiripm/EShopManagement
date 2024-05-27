using EShopManagement.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Order
{
    public interface IOrderDetailFactory
    {
        OrderDetail Create(int orderId, int productId, decimal price);
    }
}
