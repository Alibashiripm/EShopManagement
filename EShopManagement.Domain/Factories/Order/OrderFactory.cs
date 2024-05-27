using EShopManagement.Domain.ValueObjects.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Order
{
    public class OrderFactory : IOrderFactory
    {
        public Entities.Order.Order Create(decimal orderSum, bool isFinaly, OrderCreateDate createDate, int userId)
        
            =>new(orderSum,isFinaly,createDate,userId);
        
    }
}
