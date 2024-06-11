using EShopManagement.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Order
{
    public class OrderDetailFactory : IOrderDetailFactory
    {
        public OrderDetail Create(int orderId, decimal price, int? productId=null)
        => new OrderDetail(orderId, price, productId);
             
    }
}
